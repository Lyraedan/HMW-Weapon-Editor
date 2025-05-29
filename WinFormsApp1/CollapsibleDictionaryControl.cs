using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class CollapsibleDictionaryControl : UserControl
    {
        private Button toggleButton;
        private Label titleLabel;
        private Panel headerPanel;
        private Panel contentPanel;
        private Dictionary<string, TextBox> keyFields = new();
        private bool isCollapsed = false;

        private const int MaxVisibleHeight = 250;

        public Dictionary<string, object> Values
        {
            get
            {
                var result = new Dictionary<string, object>();
                foreach (var kvp in keyFields)
                    result[kvp.Key] = kvp.Value.Text;
                return result;
            }
            set
            {
                keyFields.Clear();
                contentPanel.Controls.Clear();

                int y = 5;
                foreach (var kvp in value)
                {
                    var label = new Label
                    {
                        Text = kvp.Key,
                        Location = new Point(10, y + 3),
                        Height = 22,
                        TextAlign = ContentAlignment.MiddleLeft,
                        AutoSize = false
                    };

                    var textBox = new TextBox
                    {
                        Text = kvp.Value?.ToString() ?? "",
                        Location = new Point(0, y), // will set X later dynamically
                        Height = 22,
                        Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
                    };

                    keyFields[kvp.Key] = textBox;
                    contentPanel.Controls.Add(label);
                    contentPanel.Controls.Add(textBox);
                    y += 28;
                }

                ResizeFields(); // Set widths based on current control width
                contentPanel.Height = Math.Min(y + 5, MaxVisibleHeight);
                Height = headerPanel.Height + (isCollapsed ? 0 : contentPanel.Height);
            }
        }

        public CollapsibleDictionaryControl(string title)
        {
            Width = 820;
            BorderStyle = BorderStyle.FixedSingle;

            headerPanel = new Panel
            {
                Height = 32,
                Dock = DockStyle.Top,
                Padding = new Padding(0),
            };

            toggleButton = new Button
            {
                Text = "−",
                Size = new Size(25, 25),
                Location = new Point(10, 3),
                TextAlign = ContentAlignment.MiddleCenter
            };
            toggleButton.Click += Toggle;

            titleLabel = new Label
            {
                Text = title,
                AutoSize = true,
                Location = new Point(45, 7),
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            };

            headerPanel.Controls.Add(toggleButton);
            headerPanel.Controls.Add(titleLabel);
            Controls.Add(headerPanel);

            contentPanel = new Panel
            {
                Top = headerPanel.Bottom,
                Left = 0,
                Width = Width - 4,
                AutoScroll = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Visible = true
            };

            Controls.Add(contentPanel);
            Height = headerPanel.Height + contentPanel.Height;

            // Resize event to update child widths when control resizes
            this.Resize += (s, e) => ResizeFields();

            DoToggle();
        }

        private void ResizeFields()
        {
            int availableWidth = this.Width - 40; // padding left + right

            int labelWidth = (int)(availableWidth * 0.3);
            int textBoxWidth = availableWidth - labelWidth - 20; // spacing between

            foreach (var kvp in keyFields)
            {
                if (kvp.Value.Parent != null)
                {
                    var label = (Label)kvp.Value.Parent.Controls[contentPanel.Controls.IndexOf(kvp.Value) - 1];
                    label.Width = labelWidth;
                    label.Location = new Point(10, label.Location.Y);

                    kvp.Value.Width = textBoxWidth;
                    kvp.Value.Location = new Point(label.Right + 10, kvp.Value.Location.Y);
                }
            }
        }

        private void Toggle(object sender, EventArgs e)
        {
            DoToggle();
        }

        void DoToggle()
        {
            isCollapsed = !isCollapsed;
            contentPanel.Visible = !isCollapsed;
            toggleButton.Text = isCollapsed ? "+" : "−";
            Height = headerPanel.Height + (isCollapsed ? 0 : contentPanel.Height);
        }
    }
}
