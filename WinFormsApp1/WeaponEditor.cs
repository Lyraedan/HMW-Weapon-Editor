using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.Linq;

namespace WinFormsApp1
{
    public class WeaponEditor : UserControl
    {
        private TabControl weaponTabControl;
        private Label fileLabel;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        private ContextMenuStrip tabContextMenu;

        public Action<string> OnFileChanged;

        public WeaponEditor()
        {
            AllowDrop = true;
            DragEnter += WeaponEditor_DragEnter;
            DragDrop += WeaponEditor_DragDrop;

            // MenuStrip with File menu
            var menuStrip = new MenuStrip { Dock = DockStyle.Top };
            var fileMenu = new ToolStripMenuItem("File");
            var loadMenuItem = new ToolStripMenuItem("Load JSON");
            var saveMenuItem = new ToolStripMenuItem("Save JSON");
            loadMenuItem.Click += LoadButton_Click;
            saveMenuItem.Click += SaveButton_Click;
            fileMenu.DropDownItems.Add(loadMenuItem);
            fileMenu.DropDownItems.Add(saveMenuItem);
            menuStrip.Items.Add(fileMenu);
            Controls.Add(menuStrip);

            // Main weapon TabControl fills remaining space
            weaponTabControl = new TabControl { Dock = DockStyle.Fill };
            weaponTabControl.SelectedIndexChanged += WeaponTabControl_SelectedIndexChanged;
            Controls.Add(weaponTabControl);

            // Status label docked bottom
            fileLabel = new Label
            {
                Text = "No file loaded",
                Dock = DockStyle.Bottom,
                Height = 25,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            Controls.Add(fileLabel);

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
        }

        private void WeaponTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (weaponTabControl.SelectedTab?.Tag is WeaponTabContext context)
            {
                string name = context.Weapon?.szDisplayName ?? Path.GetFileName(context.FilePath);
                fileLabel.Text = name;
                weaponTabControl.SelectedTab.Text = name;
            }
            else
            {
                fileLabel.Text = "No file loaded";
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

                    // Inner tabs dock top with fixed height to prevent overlapping outer tabs
                    TabControl innerTabs = new TabControl
                    {
                        Dock = DockStyle.Top,
                        Height = 400 // Adjust height as needed for your layout
                    };
                    weaponTab.Controls.Add(innerTabs);

                    GenerateTabsForWeapon(weaponTab, weapon);

                    weaponTabControl.TabPages.Add(weaponTab);
                    weaponTabControl.SelectedTab = weaponTab;

                    // Update status label and tab text
                    fileLabel.Text = name;
                    weaponTab.Text = name;
                    OnFileChanged.Invoke($"{name}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load file: " + ex.Message);
            }
        }

        private void GenerateTabsForWeapon(TabPage containerTab, WeaponJson weapon)
        {
            var innerTabs = containerTab.Controls.OfType<TabControl>().FirstOrDefault();
            if (innerTabs == null) return;

            innerTabs.TabPages.Clear();

            var groupedProperties = typeof(WeaponJson)
                .GetProperties()
                .GroupBy(p => p.GetCustomAttribute<GroupAttribute>()?.Name ?? "Other");

            foreach (var group in groupedProperties)
            {
                TabPage tab = new TabPage(group.Key) { AutoScroll = true };
                innerTabs.TabPages.Add(tab);

                int y = 20;
                foreach (var prop in group)
                {
                    Label label = new Label { Text = prop.Name, Left = 20, Top = y, Width = 250 };
                    Control control = GenerateControlForProperty(prop, weapon);
                    control.Left = 280;
                    control.Top = y;
                    control.Width = 300;

                    tab.Controls.Add(label);
                    tab.Controls.Add(control);

                    y += 30;
                }
            }
        }

        private Control GenerateControlForProperty(PropertyInfo prop, WeaponJson weapon)
        {
            Type type = prop.PropertyType;
            object value = prop.GetValue(weapon);

            if (type == typeof(string))
            {
                return new TextBox { Text = value as string ?? "" };
            }
            else if (type == typeof(int))
            {
                return new NumericUpDown { Value = (int)(value ?? 0), Maximum = int.MaxValue };
            }
            else if (type == typeof(float))
            {
                return new NumericUpDown { DecimalPlaces = 2, Value = Convert.ToDecimal(value ?? 0f), Maximum = decimal.MaxValue };
            }
            else if (type == typeof(bool))
            {
                return new CheckBox { Checked = (bool)(value ?? false) };
            }
            else if (type == typeof(List<string>))
            {
                return new TextBox { Text = string.Join(", ", (List<string>)value ?? new List<string>()) };
            }
            else if (type == typeof(List<float>))
            {
                return new TextBox { Text = string.Join(", ", (List<float>)value ?? new List<float>()) };
            }
            else if (type == typeof(Dictionary<string, object>))
            {
                var dict = (Dictionary<string, object>)value ?? new Dictionary<string, object>();
                var control = new CollapsibleDictionaryControl(prop.Name)
                {
                    Width = 500
                };
                control.Values = dict;
                return control;
            }
            else
            {
                return new TextBox { Text = value?.ToString() ?? "" };
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
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
                string json = JsonSerializer.Serialize(context.Weapon, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(saveFileDialog.FileName, json);
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

        private class WeaponTabContext
        {
            public WeaponJson Weapon { get; set; }
            public string FilePath { get; set; }
        }
    }
}
