using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.Linq;
using static WinFormsApp1.WeaponJson;
using Timer = System.Windows.Forms.Timer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;
using System.Text.Json.Serialization;

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
        private ToolStripProgressBar progressBar;

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
            saveCurrentMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            var saveAllMenuItem = new ToolStripMenuItem("Save All");
            var saveNewMenuItem = new ToolStripMenuItem("Save As");
            saveNewMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;

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

            var searchMenu = new ToolStripMenuItem("Search");
            var findMenuItem = new ToolStripMenuItem("Find");
            findMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            findMenuItem.Click += FindMenuItem_Click;
            searchMenu.DropDownItems.Add(findMenuItem);
            menuStrip.Items.Add(searchMenu);

            var zonetoolMenu = new ToolStripMenuItem("Zonetool");
            var linkZoneItem = new ToolStripMenuItem("Link zonetool");
            var buildZoneItem = new ToolStripMenuItem("Build zone");
            var dumpZoneItem = new ToolStripMenuItem("Dump zone");
            var loadZoneItem = new ToolStripMenuItem("Load zone");

            linkZoneItem.Click += (s, e) =>
            {
                Zonetool.LinkZonetool();
            };

            buildZoneItem.Click += (s, e) =>
            {
                string zone = Prompt.ShowDialog("Enter zone name to build:", "Build Zone");
                if (!string.IsNullOrWhiteSpace(zone))
                    Zonetool.BuildZone(zone);
            };

            dumpZoneItem.Click += (s, e) =>
            {
                string zone = Prompt.ShowDialog("Enter zone name to dump:", "Dump Zone");
                if (!string.IsNullOrWhiteSpace(zone))
                    Zonetool.DumpZone(zone);
            };

            loadZoneItem.Click += (s, e) =>
            {
                string zone = Prompt.ShowDialog("Enter zone name to load:", "Load Zone");
                if (!string.IsNullOrWhiteSpace(zone))
                    Zonetool.LoadZone(zone);
            };

            zonetoolMenu.DropDownItems.Add(linkZoneItem);
            zonetoolMenu.DropDownItems.Add(buildZoneItem);
            zonetoolMenu.DropDownItems.Add(dumpZoneItem);
            zonetoolMenu.DropDownItems.Add(loadZoneItem);
            menuStrip.Items.Add(zonetoolMenu);

            // Create About menu with Credits
            var aboutMenu = new ToolStripMenuItem("About");
            var creditsItem = new ToolStripMenuItem("Credits");
            creditsItem.Click += (s, e) =>
            {
                MessageBox.Show(
                    "HMW Weapon Editor\nAuthor: ItsLuke\nVersion: 0.3",
                    "About",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            };
            aboutMenu.DropDownItems.Add(creditsItem);
            menuStrip.Items.Add(aboutMenu); // Add About to the top-level menu

            Controls.Add(menuStrip);

            // Main weapon TabControl fills remaining space
            weaponTabControl = new TabControl { Dock = DockStyle.Fill };
            weaponTabControl.SelectedIndexChanged += WeaponTabControl_SelectedIndexChanged;
            Controls.Add(weaponTabControl);

            // Status strip docked bottom with two labels
            statusStrip = new StatusStrip();
            weaponNameStatusLabel = new ToolStripStatusLabel("Weapon: None");
            fileNameStatusLabel = new ToolStripStatusLabel("File: None") { Spring = true };
            
            progressBar = new ToolStripProgressBar
            {
                Minimum = 0,
                Maximum = 100,
                Size = new Size(100, 16),
                Value = 0,
                Visible = true // Always show; just empty when unused
            };

            statusStrip.Items.Add(weaponNameStatusLabel);
            statusStrip.Items.Add(fileNameStatusLabel);
            statusStrip.Items.Add(progressBar);
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

        private void FindMenuItem_Click(object sender, EventArgs e)
        {
            var fieldNames = GetAllLabelsAcrossTabs().Select(l => l.Text).Distinct().ToList();
            var findDialog = new FindWindow(fieldNames);
            findDialog.OnFind += (term) =>
            {
                findDialog.Close();
                PerformSearchAndScroll(term);
            };
            findDialog.ShowDialog();
        }


        private IEnumerable<Label> GetAllLabelsAcrossTabs()
        {
            foreach (TabPage mainTab in weaponTabControl.TabPages)
            {
                var innerTabs = mainTab.Controls.OfType<TabControl>().FirstOrDefault();
                if (innerTabs == null) continue;

                foreach (TabPage subTab in innerTabs.TabPages)
                {
                    foreach (Control container in subTab.Controls)
                    {
                        if (container is TableLayoutPanel layout)
                        {
                            foreach (Control c in layout.Controls)
                            {
                                if (c is Label lbl)
                                {
                                    lbl.Tag ??= lbl.Text.Trim().ToLower(); // ensure it's always tagged
                                    yield return lbl;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void PerformSearchAndScroll(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return;

            string targetTerm = searchTerm.Trim().ToLower();

            foreach (TabPage mainTab in weaponTabControl.TabPages)
            {
                var innerTabs = mainTab.Controls.OfType<TabControl>().FirstOrDefault();
                if (innerTabs == null) continue;

                foreach (TabPage subTab in innerTabs.TabPages)
                {
                    foreach (Control container in subTab.Controls)
                    {
                        if (container is TableLayoutPanel layout)
                        {
                            for (int i = 0; i < layout.Controls.Count - 1; i += 2)
                            {
                                if (layout.Controls[i] is Label label)
                                {
                                    string labelKey = label.Tag?.ToString()?.ToLower() ?? label.Text.Trim().ToLower();

                                    if (labelKey == targetTerm ||
                                        labelKey.Contains(targetTerm) ||
                                        LevenshteinDistance(labelKey, targetTerm) <= 1)
                                    {
                                        weaponTabControl.SelectedTab = mainTab;
                                        innerTabs.SelectedTab = subTab;

                                        Control input = layout.Controls[i + 1];
                                        layout.ScrollControlIntoView(input);
                                        input.BackColor = Color.LightYellow;

                                        var timer = new Timer { Interval = 1500 };
                                        timer.Tick += (s, e) =>
                                        {
                                            input.BackColor = SystemColors.Window;
                                            timer.Stop();
                                            timer.Dispose();
                                        };
                                        timer.Start();

                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            MessageBox.Show($"No match found for '{searchTerm}'.", "Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int LevenshteinDistance(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            for (int i = 0; i <= n; i++) d[i, 0] = i;
            for (int j = 0; j <= m; j++) d[0, j] = j;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = s[i - 1] == t[j - 1] ? 0 : 1;
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }

            return d[n, m];
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
            newWeapon.szXAnimsRightHanded = StaticReadonly.AnimDictKeys.ToDictionary(k => k,k => (object)"");
            newWeapon.szXAnimsLeftHanded = StaticReadonly.AnimDictKeys.ToDictionary(k => k, k => (object)"");
            newWeapon.szXAnims = StaticReadonly.AnimDictKeys.ToDictionary(k => k, k => (object)"");

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
                string weaponName = (string) context.Weapon?.szDisplayName ?? Path.GetFileName(context.FilePath);
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
                progressBar.Value = 10;
                Application.DoEvents();

                string json = File.ReadAllText(path);
                progressBar.Value = 40;
                Application.DoEvents();

                var options = new JsonSerializerOptions
                {
                    Converters = { new JsonElementToObjectConverter() },
                    PropertyNameCaseInsensitive = true
                };

                var weapon = JsonSerializer.Deserialize<WeaponJson>(json, options);
                progressBar.Value = 70;

                if (weapon != null)
                {
                    string name = (string)weapon.szDisplayName ?? Path.GetFileName(path);
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
                    MessageBox.Show($"Successfully loaded: {name}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                progressBar.Value = 100;
                Task.Delay(300).ContinueWith(_ =>
                {
                    if (!IsDisposed)
                        Invoke(() => progressBar.Value = 0);
                });
            }
            catch (Exception ex)
            {
                progressBar.Value = 0;
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
                var actualType = val?.GetType() ?? prop.PropertyType;

                if (IsCustomClass(actualType) && val != null)
                {
                    // Get nested class properties
                    return actualType.GetProperties().Select(subProp => new
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
                    AutoSize = false,
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

                        var label = new Label
                        {
                            Text = property.Name,
                            AutoSize = true,
                            Tag = property.Name.Trim().ToLower()
                        };

                        var control = GenerateControlForProperty(property, target);
                        control.Tag = property.Name.Trim().ToLower();

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
            object value = prop.GetValue(targetObject);
            Type actualType = value?.GetType() ?? prop.PropertyType;

            if (actualType == typeof(string))
            {
                return new TextBox
                {
                    Text = value as string ?? "",
                    Dock = DockStyle.Fill,
                    Margin = new Padding(3)
                };
            }
            else if (actualType == typeof(int))
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
            else if (actualType == typeof(float) || actualType == typeof(double) || (value is JsonElement je && je.ValueKind == JsonValueKind.Number))
            {
                float floatVal = 0f;

                if (value is JsonElement jeFloat)
                {
                    floatVal = jeFloat.GetSingle();
                }
                else
                {
                    floatVal = Convert.ToSingle(value);
                }

                var decimalPlaces = floatVal % 1 == 0 ? 1 : 6; // show .0 if whole, else up to 6 decimal digits

                var fNud = new NumericUpDown
                {
                    Increment = 0.1M,
                    Minimum = -1000000,
                    Maximum = 1000000,
                    DecimalPlaces = decimalPlaces,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(3)
                };

                fNud.Value = ClampDecimal(floatVal, fNud.Minimum, fNud.Maximum);
                return fNud;
            }
            else if (actualType == typeof(bool))
            {
                return new CheckBox
                {
                    Checked = value is bool b && b,
                    AutoSize = true,
                    Margin = new Padding(3)
                };
            }
            else if (actualType == typeof(List<string>))
            {
                return new TextBox
                {
                    Text = string.Join(", ", (List<string>)value ?? new List<string>()),
                    Dock = DockStyle.Fill,
                    Margin = new Padding(3)
                };
            }
            else if (actualType == typeof(List<float>))
            {
                return new TextBox
                {
                    Text = string.Join(", ", (List<float>)value ?? new List<float>()),
                    Dock = DockStyle.Fill,
                    Margin = new Padding(3)
                };
            }
            else if (actualType == typeof(List<int>))
            {
                return new TextBox
                {
                    Text = string.Join(", ", (List<int>)value ?? new List<int>()),
                    Dock = DockStyle.Fill,
                    Margin = new Padding(3)
                };
            }
            else if (actualType == typeof(List<object>) && value is List<object> listObj && listObj.Count > 0)
            {
                var distinctTypes = listObj.Select(v => v?.GetType()).Distinct().ToList();

                if (distinctTypes.Count == 1)
                {
                    var type = distinctTypes[0];
                    if (type == typeof(float) || type == typeof(double))
                    {
                        return new TextBox
                        {
                            Text = string.Join(", ", listObj.Select(v => $"{Convert.ToSingle(v):0.0######}")),
                            Dock = DockStyle.Fill,
                            Margin = new Padding(3)
                        };
                    }
                    else if (type == typeof(int))
                    {
                        return new TextBox
                        {
                            Text = string.Join(", ", listObj.Cast<int>()),
                            Dock = DockStyle.Fill,
                            Margin = new Padding(3)
                        };
                    }
                    else if (type == typeof(string))
                    {
                        return new TextBox
                        {
                            Text = string.Join(", ", listObj.Cast<string>()),
                            Dock = DockStyle.Fill,
                            Margin = new Padding(3)
                        };
                    }
                }

                // Mixed or unknown types fallback
                return new TextBox
                {
                    Text = string.Join(", ", listObj.Select(o =>
                    {
                        if (o is float f) return $"{f:0.0######}";
                        if (o is double d) return $"{d:0.0######}";
                        return o?.ToString() ?? "";
                    })),
                    Dock = DockStyle.Fill,
                    Margin = new Padding(3)
                };
            }
            else if (actualType == typeof(Dictionary<string, object>))
            {
                return new CollapsibleDictionaryControl(prop.Name)
                {
                    Dock = DockStyle.Fill,
                    Values = value as Dictionary<string, object> ?? new Dictionary<string, object>(),
                    Margin = new Padding(3)
                };
            }
            else if (actualType == typeof(Dictionary<string, string>))
            {
                var dict = (IDictionary<string, string>)value;
                return new CollapsibleDictionaryControl(prop.Name)
                {
                    Dock = DockStyle.Fill,
                    Values = dict?.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value) ?? new Dictionary<string, object>(),
                    Margin = new Padding(3)
                };
            }

            return new TextBox
            {
                Text = value?.ToString() ?? "",
                Dock = DockStyle.Fill,
                Margin = new Padding(3)
            };
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
            SaveAll();
        }


        private void SaveNewFile_Click(object sender, EventArgs e)
        {
            SaveCurrentFileAs();
        }

        public void SaveCurrentFile()
        {
            if (weaponTabControl.SelectedTab?.Tag is not WeaponTabContext context) return;

            SaveTabEditsToWeapon(context);

            if (string.IsNullOrEmpty(context.FilePath))
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                context.FilePath = saveFileDialog.FileName;
            }

            SaveToFile(context, context.FilePath);
        }

        private void SaveCurrentFileAs()
        {
            if (weaponTabControl.SelectedTab?.Tag is not WeaponTabContext context) return;

            SaveTabEditsToWeapon(context);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                context.FilePath = saveFileDialog.FileName;
                SaveToFile(context, context.FilePath);
            }
        }

        private void SaveAll()
        {
            progressBar.Value = 10;

            try
            {
                foreach (TabPage tab in weaponTabControl.TabPages)
                {
                    weaponTabControl.SelectedTab = tab;

                    if (tab.Tag is not WeaponTabContext context)
                        continue;

                    SaveCurrentFile();
                }

                MessageBox.Show("All files saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save all files: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Task.Delay(750).ContinueWith(_ =>
                {
                    if (!IsDisposed)
                    {
                        Invoke(() => progressBar.Value = 0);
                    }
                });
            }
        }

        private void SaveToFile(WeaponTabContext context, string filePath)
        {
            try
            {
                string json = JsonSerializer.Serialize(context.Weapon, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
                });

                File.WriteAllText(filePath, json);

                dirtyFlags[weaponTabControl.SelectedTab] = false;
                UpdateFileLabelAndSaveCurrentMenu();
                OnFileChanged?.Invoke($"{context.Weapon.szDisplayName ?? Path.GetFileName(filePath)}");

                MessageBox.Show("Save completed.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save file: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveTabEditsToWeapon(WeaponTabContext context)
        {
            var innerTabs = weaponTabControl.SelectedTab.Controls.OfType<TabControl>().FirstOrDefault();
            if (innerTabs == null) return;

            foreach (TabPage tab in innerTabs.TabPages)
            {
                var layout = tab.Controls.OfType<TableLayoutPanel>().FirstOrDefault();
                if (layout == null) continue;

                for (int i = 0; i < layout.Controls.Count - 1; i++)
                {
                    if (layout.Controls[i] is Label label)
                    {
                        string propName = label.Text;
                        Control inputControl = layout.Controls[i + 1];

                        try
                        {
                            var prop = context.Weapon.GetType().GetProperty(propName);
                            if (prop != null && prop.CanWrite)
                            {
                                object parsedValue = ParseControlValue(inputControl, prop.PropertyType);
                                prop.SetValue(context.Weapon, parsedValue);
                            }
                            else
                            {
                                foreach (var containerProp in context.Weapon.GetType().GetProperties())
                                {
                                    if (containerProp.PropertyType.IsClass &&
                                        containerProp.PropertyType != typeof(string) &&
                                        containerProp.GetValue(context.Weapon) is object container)
                                    {
                                        var nested = containerProp.PropertyType.GetProperty(propName);
                                        if (nested != null && nested.CanWrite)
                                        {
                                            object parsed = ParseControlValue(inputControl, nested.PropertyType);
                                            nested.SetValue(container, parsed);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to parse or set value for {propName}: {ex.Message}", "Save Error");
                        }
                    }
                }
            }
        }


        private object ParseControlValue(Control control, Type type)
        {
            if (type == typeof(object))
            {
                // Dynamically guess type based on control
                if (control is NumericUpDown nud)
                {
                    return nud.DecimalPlaces > 0 ? (object)(float)nud.Value : (int)nud.Value;
                }
                else if (control is CheckBox cb)
                {
                    return cb.Checked;
                }
                else if (control is TextBox tb)
                {
                    string text = tb.Text.Trim();

                    if (string.IsNullOrWhiteSpace(text))
                        return "";

                    if (bool.TryParse(text, out bool boolVal))
                        return boolVal;

                    if (int.TryParse(text, out int intVal))
                        return intVal;

                    if (float.TryParse(text, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out float floatVal))
                        return floatVal;

                    // Try parsing as comma-separated list
                    var parts = text.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length > 1)
                    {
                        if (parts.All(p => int.TryParse(p, out _)))
                            return parts.Select(int.Parse).Cast<object>().ToList();

                        if (parts.All(p => float.TryParse(p, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out _)))
                            return parts.Select(p => (object)float.Parse(p, System.Globalization.CultureInfo.InvariantCulture)).ToList();

                        return parts.Cast<object>().ToList();
                    }

                    return text;
                }
            }

            if (type == typeof(string))
                return control.Text ?? "";

            if (type == typeof(int))
                return (int)((NumericUpDown)control).Value;

            if (type == typeof(float))
                return (float)((NumericUpDown)control).Value;

            if (type == typeof(bool))
                return ((CheckBox)control).Checked;

            if (type == typeof(List<string>))
                return control.Text.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (type == typeof(List<float>))
            {
                var parts = control.Text.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                return parts
                    .Where(p => float.TryParse(p, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out _))
                    .Select(p => float.Parse(p, System.Globalization.CultureInfo.InvariantCulture))
                    .ToList();
            }

            if (type == typeof(List<int>))
            {
                var parts = control.Text.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                return parts
                    .Where(p => int.TryParse(p, out _))
                    .Select(int.Parse)
                    .ToList();
            }

            if (type == typeof(Dictionary<string, object>))
            {
                if (control is CollapsibleDictionaryControl cdc)
                    return cdc.Values;
                return new Dictionary<string, object>();
            }

            if (type == typeof(List<object>))
            {
                var parts = control.Text.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.All(p => int.TryParse(p, out _)))
                    return parts.Select(p => (object)int.Parse(p)).ToList();

                if (parts.All(p => float.TryParse(p, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out _)))
                    return parts.Select(p => (object)float.Parse(p, System.Globalization.CultureInfo.InvariantCulture)).ToList();

                return parts.Cast<object>().ToList();
            }

            return control.Text ?? "";
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

        private string FormatObjectForDisplay(object o)
        {
            if (o is float f)
                return f.ToString("0.##");
            return o?.ToString() ?? "";
        }

        private class WeaponTabContext
        {
            public WeaponJson Weapon { get; set; }
            public string FilePath { get; set; }
        }
    }
}
