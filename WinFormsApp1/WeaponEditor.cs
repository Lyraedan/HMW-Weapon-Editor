
using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;

namespace WinFormsApp1
{
    public class WeaponEditor : UserControl
    {
        private TabControl weaponTabControl;
        private Button saveButton;
        private Button loadButton;
        private Label fileLabel;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;

        public WeaponEditor()
        {
            AllowDrop = true;
            DragEnter += WeaponEditor_DragEnter;
            DragDrop += WeaponEditor_DragDrop;

            weaponTabControl = new TabControl { Dock = DockStyle.Fill };
            weaponTabControl.SelectedIndexChanged += WeaponTabControl_SelectedIndexChanged;
            Controls.Add(weaponTabControl);

            Panel topPanel = new Panel { Dock = DockStyle.Top, Height = 40 };
            fileLabel = new Label { Text = "No file loaded", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
            topPanel.Controls.Add(fileLabel);
            Controls.Add(topPanel);

            loadButton = new Button { Text = "Load JSON", Dock = DockStyle.Top, Height = 40 };
            loadButton.Click += LoadButton_Click;
            Controls.Add(loadButton);

            saveButton = new Button { Text = "Save JSON", Dock = DockStyle.Bottom, Height = 40 };
            saveButton.Click += SaveButton_Click;
            Controls.Add(saveButton);

            saveFileDialog = new SaveFileDialog { Filter = "JSON Files (*.json)|*.json" };
            openFileDialog = new OpenFileDialog { Filter = "JSON Files (*.json)|*.json" };
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
                    TabPage tab = new TabPage(name);
                    tab.Tag = new WeaponTabContext { Weapon = weapon, FilePath = path };
                    GenerateTabsForWeapon(tab, weapon);
                    weaponTabControl.TabPages.Add(tab);
                    weaponTabControl.SelectedTab = tab;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load file: " + ex.Message);
            }
        }

        private void GenerateTabsForWeapon(TabPage containerTab, WeaponJson weapon)
        {
            TabControl innerTabs = new TabControl { Dock = DockStyle.Fill };
            containerTab.Controls.Add(innerTabs);

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

            TabControl innerTabs = (TabControl)weaponTabControl.SelectedTab.Controls[0];

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

        private class WeaponTabContext
        {
            public WeaponJson Weapon { get; set; }
            public string FilePath { get; set; }
        }
    }
}
