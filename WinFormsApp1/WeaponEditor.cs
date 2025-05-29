using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.Linq;
using static WinFormsApp1.WeaponJson;

namespace WinFormsApp1
{
    public class WeaponEditor : UserControl
    {
        private TabControl weaponTabControl;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel weaponNameStatusLabel;
        private ToolStripStatusLabel fileNameStatusLabel;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        private ContextMenuStrip tabContextMenu;

        private ToolStripMenuItem saveCurrentMenuItem;

        // Track dirty state per tab
        private Dictionary<TabPage, bool> dirtyFlags = new();

        public Action<string> OnFileChanged;

        public WeaponEditor()
        {
            AllowDrop = true;
            DragEnter += WeaponEditor_DragEnter;
            DragDrop += WeaponEditor_DragDrop;

            // MenuStrip with File menu including New, Save submenu, and Load JSON
            var menuStrip = new MenuStrip { Dock = DockStyle.Top };

            var fileMenu = new ToolStripMenuItem("File");

            var newMenuItem = new ToolStripMenuItem("New");
            newMenuItem.Click += NewMenuItem_Click;

            var saveMenu = new ToolStripMenuItem("Save");
            saveCurrentMenuItem = new ToolStripMenuItem("Save Current File") { Enabled = false };
            var saveAllMenuItem = new ToolStripMenuItem("Save All");
            var saveNewMenuItem = new ToolStripMenuItem("Save New");

            saveCurrentMenuItem.Click += SaveCurrentFile_Click;
            saveAllMenuItem.Click += SaveAllButton_Click;
            saveNewMenuItem.Click += SaveNewFile_Click;

            saveMenu.DropDownItems.Add(saveNewMenuItem);
            saveMenu.DropDownItems.Add(saveCurrentMenuItem);
            saveMenu.DropDownItems.Add(saveAllMenuItem);

            var loadMenuItem = new ToolStripMenuItem("Load JSON");
            loadMenuItem.Click += LoadButton_Click;

            fileMenu.DropDownItems.Add(newMenuItem);
            fileMenu.DropDownItems.Add(loadMenuItem);
            fileMenu.DropDownItems.Add(saveMenu);

            menuStrip.Items.Add(fileMenu);
            Controls.Add(menuStrip);

            // Main weapon TabControl fills remaining space
            weaponTabControl = new TabControl { Dock = DockStyle.Fill };
            weaponTabControl.SelectedIndexChanged += WeaponTabControl_SelectedIndexChanged;
            Controls.Add(weaponTabControl);

            // Status strip docked bottom with two labels
            statusStrip = new StatusStrip();
            weaponNameStatusLabel = new ToolStripStatusLabel("Weapon: None");
            fileNameStatusLabel = new ToolStripStatusLabel("File: None") { Spring = true };

            statusStrip.Items.Add(weaponNameStatusLabel);
            statusStrip.Items.Add(fileNameStatusLabel);
            Controls.Add(statusStrip);

            saveFileDialog = new SaveFileDialog { Filter = "JSON Files (*.json)|*.json" };
            openFileDialog = new OpenFileDialog { Filter = "JSON Files (*.json)|*.json" };

            // Tab context menu for right-click on weapon tabs
            tabContextMenu = new ContextMenuStrip();
            var closeItem = new ToolStripMenuItem("Close");
            var closeAllItem = new ToolStripMenuItem("Close All");
            closeItem.Click += CloseTab_Click;
            closeAllItem.Click += CloseAllTabs_Click;
            tabContextMenu.Items.AddRange(new ToolStripItem[] { closeItem, closeAllItem });

            weaponTabControl.MouseUp += WeaponTabControl_MouseUp;

            // Hook key preview for Ctrl+S and Ctrl+Shift+S shortcuts
            this.PreviewKeyDown += WeaponEditor_PreviewKeyDown;
            this.KeyDown += WeaponEditor_KeyDown;
        }

        private void NewMenuItem_Click(object sender, EventArgs e)
        {
            var newWeapon = new WeaponJson(); // You can customize default values here if needed

            newWeapon.accuracy_graph = new AccuracyGraph();
            newWeapon.overlay = new Overlay();
            newWeapon.sounds = new Sounds();
            newWeapon.stateTimers = new StateTimers();
            newWeapon.stateTimersAkimbo = new StateTimers();
            // add any other nested classes here...

            // Initialize anim dictionaries with all keys set to empty strings
            newWeapon.szXAnimsRightHanded = StaticReadonly.AnimDictKeys.ToDictionary(k => k, k => "");
            newWeapon.szXAnimsLeftHanded = StaticReadonly.AnimDictKeys.ToDictionary(k => k, k => "");
            newWeapon.szXAnims = StaticReadonly.AnimDictKeys.ToDictionary(k => k, k => "");

            TabPage newTab = new TabPage("New Weapon");
            newTab.Tag = new WeaponTabContext { Weapon = newWeapon, FilePath = null };

            TabControl innerTabs = new TabControl
            {
                Dock = DockStyle.Fill,
            };
            newTab.Controls.Add(innerTabs);

            GenerateTabsForWeapon(newTab, newWeapon);

            weaponTabControl.TabPages.Add(newTab);
            weaponTabControl.SelectedTab = newTab;

            dirtyFlags[newTab] = true;
            UpdateFileLabelAndSaveCurrentMenu();
            OnFileChanged?.Invoke("New Weapon*");
        }

        private void WeaponEditor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }

        private void WeaponEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                if (e.Shift)
                {
                    SaveCurrentFileAs();
                }
                else
                {
                    SaveCurrentFile();
                }
                e.Handled = true;
            }
        }

        private void WeaponTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFileLabelAndSaveCurrentMenu();
        }

        private void UpdateFileLabelAndSaveCurrentMenu()
        {
            if (weaponTabControl.SelectedTab?.Tag is WeaponTabContext context)
            {
                string weaponName = context.Weapon?.szDisplayName ?? Path.GetFileName(context.FilePath);
                if (dirtyFlags.TryGetValue(weaponTabControl.SelectedTab, out bool dirty) && dirty)
                {
                    weaponName += "*";
                }
                weaponNameStatusLabel.Text = $"Weapon: {weaponName}";
                fileNameStatusLabel.Text = $"File: {Path.GetFileName(context.FilePath) ?? "None"}";
                saveCurrentMenuItem.Enabled = true;
                weaponTabControl.SelectedTab.Text = weaponName;
            }
            else
            {
                weaponNameStatusLabel.Text = "Weapon: None";
                fileNameStatusLabel.Text = "File: None";
                saveCurrentMenuItem.Enabled = false;
            }
        }

        private void WeaponEditor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void WeaponEditor_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var file in files)
            {
                LoadWeaponFile(file);
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadWeaponFile(openFileDialog.FileName);
            }
        }

        private void LoadWeaponFile(string path)
        {
            try
            {
                string json = File.ReadAllText(path);
                var weapon = JsonSerializer.Deserialize<WeaponJson>(json);
                if (weapon != null)
                {
                    string name = weapon.szDisplayName ?? Path.GetFileName(path);
                    TabPage weaponTab = new TabPage(name);
                    weaponTab.Tag = new WeaponTabContext { Weapon = weapon, FilePath = path };

                    TabControl innerTabs = new TabControl
                    {
                        Dock = DockStyle.Fill,
                    };
                    weaponTab.Controls.Add(innerTabs);

                    GenerateTabsForWeapon(weaponTab, weapon);

                    weaponTabControl.TabPages.Add(weaponTab);
                    weaponTabControl.SelectedTab = weaponTab;

                    dirtyFlags[weaponTab] = false;

                    UpdateFileLabelAndSaveCurrentMenu();
                    OnFileChanged?.Invoke($"{name}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load file: " + ex.Message);
            }
        }

        private void GenerateTabsForWeapon(TabPage tabPage, WeaponJson weapon)
        {
            var innerTabs = tabPage.Controls.OfType<TabControl>().FirstOrDefault();
            if (innerTabs == null) return;

            var allProperties = weapon.GetType().GetProperties();

            var flattenedProps = allProperties.SelectMany(prop =>
            {
                var groupAttr = prop.GetCustomAttribute<GroupAttribute>();
                var val = prop.GetValue(weapon);

                if (IsCustomClass(prop.PropertyType) && val != null)
                {
                    // Get nested class properties
                    return prop.PropertyType.GetProperties().Select(subProp => new
                    {
                        Property = subProp,
                        Target = val,
                        GroupAttr = subProp.GetCustomAttribute<GroupAttribute>()
                    });
                }
                else
                {
                    return new[]
                    {
                new
                {
                    Property = prop,
                    Target = (object)weapon,
                    GroupAttr = groupAttr
                }
            };
                }
            });

            var groupedByGroup = flattenedProps.GroupBy(x => x.GroupAttr?.Group ?? "Other");

            foreach (var group in groupedByGroup)
            {
                var groupTab = new TabPage(group.Key);
                var layout = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    ColumnCount = 2,
                    RowCount = 0,
                    AutoSize = false, // Important
                    AutoSizeMode = AutoSizeMode.GrowAndShrink
                };

                var groupedBySubgroup = group.GroupBy(x => x.GroupAttr?.SubGroup ?? "");

                foreach (var subgroup in groupedBySubgroup)
                {
                    if (!string.IsNullOrWhiteSpace(subgroup.Key))
                    {
                        var label = new Label
                        {
                            Text = subgroup.Key,
                            Font = new Font(SystemFonts.DefaultFont, FontStyle.Bold),
                            AutoSize = true,
                            Padding = new Padding(0, 10, 0, 0)
                        };
                        layout.Controls.Add(label);
                        layout.SetColumnSpan(label, 2);
                        layout.RowCount++;
                    }

                    foreach (var item in subgroup)
                    {
                        var property = item.Property;
                        var target = item.Target;
                        var label = new Label { Text = property.Name, AutoSize = true };
                        var control = GenerateControlForProperty(property, target);
                        layout.Controls.Add(label);
                        layout.Controls.Add(control);
                        layout.RowCount++;
                    }
                }

                groupTab.Controls.Add(layout);
                innerTabs.TabPages.Add(groupTab);
            }
        }

        private void AddPropertyControlToTab(TabPage tab, PropertyInfo prop, object targetObject, int y)
        {
            Label label = new Label { Text = prop.Name, Left = 20, Top = y, Width = 250 };
            Control control = GenerateControlForProperty(prop, targetObject);
            control.Left = 280;
            control.Top = y;
            control.Width = 300;

            HookControlChangedEvent(control, tab.Parent as TabPage ?? tab);

            tab.Controls.Add(label);
            tab.Controls.Add(control);
        }

        private bool IsCustomClass(Type type)
        {
            return type.IsClass && type != typeof(string) &&
                   !typeof(System.Collections.IEnumerable).IsAssignableFrom(type);
        }


        private void HookControlChangedEvent(Control control, TabPage parentTab)
        {
            void MarkDirty(object sender, EventArgs e)
            {
                if (!dirtyFlags.TryGetValue(parentTab, out bool dirty) || dirty == false)
                {
                    dirtyFlags[parentTab] = true;
                    UpdateFileLabelAndSaveCurrentMenu();
                    OnFileChanged?.Invoke($"{parentTab.Text}*");
                }
            }

            switch (control)
            {
                case TextBox tb:
                    tb.TextChanged += MarkDirty;
                    break;
                case NumericUpDown nud:
                    nud.ValueChanged += MarkDirty;
                    break;
                case CheckBox cb:
                    cb.CheckedChanged += MarkDirty;
                    break;
                case CollapsibleDictionaryControl cdc:
                    // Add dictionary change events here if implemented
                    break;
            }
        }

        private Control GenerateControlForProperty(PropertyInfo prop, object targetObject)
        {
            Type type = prop.PropertyType;
            object value = prop.GetValue(targetObject);

            if (type == typeof(string))
            {
                return new TextBox
                {
                    Text = value as string ?? "",
                    Dock = DockStyle.Fill,
                    Margin = new Padding(3)
                };
            }
            else if (type == typeof(int))
            {
                var nud = new NumericUpDown
                {
                    Minimum = int.MinValue,
                    Maximum = int.MaxValue,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(3)
                };
                nud.Value = ClampDecimal(value ?? 0, nud.Minimum, nud.Maximum);
                return nud;
            }
            else if (type == typeof(float))
            {
                var fNud = new NumericUpDown
                {
                    DecimalPlaces = 2,
                    Increment = 0.1M,
                    Minimum = -1000000,
                    Maximum = 1000000,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(3)
                };
                fNud.Value = ClampDecimal(value ?? 0f, fNud.Minimum, fNud.Maximum);
                return fNud;
            }
            else if (type == typeof(bool))
            {
                return new CheckBox
                {
                    Checked = (bool)(value ?? false),
                    AutoSize = true,
                    Margin = new Padding(3)
                };
            }
            else if (type == typeof(List<string>))
            {
                return new TextBox
                {
                    Text = string.Join(", ", (List<string>)value ?? new List<string>()),
                    Dock = DockStyle.Fill,
                    Margin = new Padding(3)
                };
            }
            else if (type == typeof(List<float>))
            {
                return new TextBox
                {
                    Text = string.Join(", ", (List<float>)value ?? new List<float>()),
                    Dock = DockStyle.Fill,
                    Margin = new Padding(3)
                };
            }
            else if (type == typeof(List<int>))
            {
                return new TextBox
                {
                    Text = string.Join(", ", (List<int>)value ?? new List<int>()),
                    Dock = DockStyle.Fill,
                    Margin = new Padding(3)
                };
            }
            else if (type == typeof(Dictionary<string, object>))
            {
                return new CollapsibleDictionaryControl(prop.Name)
                {
                    Dock = DockStyle.Fill,
                    Values = value as Dictionary<string, object> ?? new Dictionary<string, object>(),
                    Margin = new Padding(3)
                };
            }
            else if (type == typeof(Dictionary<string, string>))
            {
                var dict = (IDictionary<string, string>)value;
                return new CollapsibleDictionaryControl(prop.Name)
                {
                    Dock = DockStyle.Fill,
                    Values = dict?.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value) ?? new Dictionary<string, object>(),
                    Margin = new Padding(3)
                };
            }
            else
            {
                return new TextBox
                {
                    Text = value?.ToString() ?? "",
                    Dock = DockStyle.Fill,
                    Margin = new Padding(3)
                };
            }
        }


        private decimal ClampDecimal(object input, decimal min, decimal max)
        {
            decimal val = Convert.ToDecimal(input);
            return Math.Min(Math.Max(val, min), max);
        }


        private void SaveCurrentFile_Click(object sender, EventArgs e)
        {
            SaveCurrentFile();
        }

        private void SaveAllButton_Click(object sender, EventArgs e)
        {
            foreach (TabPage tab in weaponTabControl.TabPages)
            {
                weaponTabControl.SelectedTab = tab;
                SaveCurrentFile();
            }
        }

        private void SaveNewFile_Click(object sender, EventArgs e)
        {
            SaveCurrentFileAs();
        }

        public void SaveCurrentFile()
        {
            if (weaponTabControl.SelectedTab?.Tag is not WeaponTabContext context) return;

            var innerTabs = weaponTabControl.SelectedTab.Controls.OfType<TabControl>().FirstOrDefault();
            if (innerTabs == null) return;

            foreach (TabPage tab in innerTabs.TabPages)
            {
                foreach (Control control in tab.Controls)
                {
                    if (control is Label lbl)
                    {
                        string propName = lbl.Text;
                        Control inputControl = tab.Controls[tab.Controls.IndexOf(lbl) + 1];
                        PropertyInfo prop = typeof(WeaponJson).GetProperty(propName);
                        if (prop == null || !prop.CanWrite) continue;

                        try
                        {
                            object parsedValue = ParseControlValue(inputControl, prop.PropertyType);
                            prop.SetValue(context.Weapon, parsedValue);
                        }
                        catch { }
                    }
                }
            }

            if (string.IsNullOrEmpty(context.FilePath))
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                context.FilePath = saveFileDialog.FileName;
            }

            string json = JsonSerializer.Serialize(context.Weapon, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(context.FilePath, json);

            dirtyFlags[weaponTabControl.SelectedTab] = false;
            UpdateFileLabelAndSaveCurrentMenu();
            OnFileChanged?.Invoke($"{context.Weapon.szDisplayName ?? Path.GetFileName(context.FilePath)}");
        }

        private void SaveCurrentFileAs()
        {
            if (weaponTabControl.SelectedTab?.Tag is not WeaponTabContext context) return;

            var innerTabs = weaponTabControl.SelectedTab.Controls.OfType<TabControl>().FirstOrDefault();
            if (innerTabs == null) return;

            foreach (TabPage tab in innerTabs.TabPages)
            {
                foreach (Control control in tab.Controls)
                {
                    if (control is Label lbl)
                    {
                        string propName = lbl.Text;
                        Control inputControl = tab.Controls[tab.Controls.IndexOf(lbl) + 1];
                        PropertyInfo prop = typeof(WeaponJson).GetProperty(propName);
                        if (prop == null || !prop.CanWrite) continue;

                        try
                        {
                            object parsedValue = ParseControlValue(inputControl, prop.PropertyType);
                            prop.SetValue(context.Weapon, parsedValue);
                        }
                        catch { }
                    }
                }
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                context.FilePath = saveFileDialog.FileName;
                string json = JsonSerializer.Serialize(context.Weapon, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(context.FilePath, json);

                dirtyFlags[weaponTabControl.SelectedTab] = false;
                UpdateFileLabelAndSaveCurrentMenu();
                OnFileChanged?.Invoke($"{context.Weapon.szDisplayName ?? Path.GetFileName(context.FilePath)}");
            }
        }

        private object ParseControlValue(Control control, Type type)
        {
            if (type == typeof(string))
                return control.Text;

            if (type == typeof(int))
                return (int)((NumericUpDown)control).Value;

            if (type == typeof(float))
                return (float)((NumericUpDown)control).Value;

            if (type == typeof(bool))
                return ((CheckBox)control).Checked;

            if (type == typeof(List<string>))
                return new List<string>(control.Text.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries));

            if (type == typeof(List<float>))
            {
                var parts = control.Text.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                List<float> floats = new();
                foreach (var p in parts)
                    if (float.TryParse(p, out var f))
                        floats.Add(f);
                return floats;
            }

            if (type == typeof(List<int>))
            {
                var parts = control.Text.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                List<int> ints = new();
                foreach (var p in parts)
                    if (int.TryParse(p, out var i))
                        ints.Add(i);
                return ints;
            }

            if (type == typeof(Dictionary<string, object>))
            {
                if (control is CollapsibleDictionaryControl cdc)
                    return cdc.Values;
                return new Dictionary<string, object>();
            }

            return control.Text;
        }

        private void WeaponTabControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < weaponTabControl.TabCount; i++)
                {
                    Rectangle r = weaponTabControl.GetTabRect(i);
                    if (r.Contains(e.Location))
                    {
                        weaponTabControl.SelectedIndex = i;  // Select the tab under the mouse
                        tabContextMenu.Show(weaponTabControl, e.Location);
                        break;
                    }
                }
            }
        }

        private void CloseTab_Click(object sender, EventArgs e)
        {
            if (weaponTabControl.SelectedTab != null)
            {
                weaponTabControl.TabPages.Remove(weaponTabControl.SelectedTab);
            }
        }

        private void CloseAllTabs_Click(object sender, EventArgs e)
        {
            weaponTabControl.TabPages.Clear();
        }

        public IEnumerable<TabPage> GetDirtyTabs()
        {
            return dirtyFlags.Where(kvp => kvp.Value).Select(kvp => kvp.Key);
        }

        public void SelectTab(TabPage tab)
        {
            if (weaponTabControl.TabPages.Contains(tab))
                weaponTabControl.SelectedTab = tab;
        }

        private class WeaponTabContext
        {
            public WeaponJson Weapon { get; set; }
            public string FilePath { get; set; }
        }
    }
}
