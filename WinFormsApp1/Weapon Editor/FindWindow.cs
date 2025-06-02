using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class FindWindow : Form
    {
        private TextBox inputBox;
        private Button findButton;
        private ListBox suggestionBox;

        public event Action<string> OnFind;

        private List<string> allFields;

        public FindWindow(IEnumerable<string> availableFields)
        {
            allFields = availableFields?.ToList() ?? new();

            Text = "Find Property";
            Width = 400;
            Height = 200;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;

            inputBox = new TextBox { Left = 10, Top = 10, Width = 360 };
            inputBox.TextChanged += InputBox_TextChanged;
            inputBox.KeyDown += InputBox_KeyDown;

            findButton = new Button { Text = "Find", Left = 290, Top = 40, Width = 80 };
            findButton.Click += (s, e) => FireSearch(inputBox.Text);

            suggestionBox = new ListBox
            {
                Left = 10,
                Top = 70,
                Width = 360,
                Height = 80,
                Visible = false
            };
            suggestionBox.Click += (s, e) =>
            {
                if (suggestionBox.SelectedItem is string selected)
                    FireSearch(selected);
            };

            Controls.Add(inputBox);
            Controls.Add(findButton);
            Controls.Add(suggestionBox);
        }

        private void InputBox_TextChanged(object sender, EventArgs e)
        {
            string term = inputBox.Text.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(term))
            {
                suggestionBox.Visible = false;
                return;
            }

            var matches = allFields
                .Where(f => f.ToLower().Contains(term) || Levenshtein(term, f.ToLower()) <= 2)
                .Distinct()
                .Take(10)
                .ToList();

            suggestionBox.Items.Clear();
            suggestionBox.Visible = matches.Count > 0;
            suggestionBox.Items.AddRange(matches.ToArray());
        }

        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!suggestionBox.Visible) return;

            if (e.KeyCode == Keys.Down)
            {
                suggestionBox.Focus();
                if (suggestionBox.Items.Count > 0)
                    suggestionBox.SelectedIndex = 0;
                e.Handled = true;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (ActiveControl == suggestionBox && keyData == Keys.Enter)
            {
                if (suggestionBox.SelectedItem is string selected)
                {
                    FireSearch(selected);
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FireSearch(string term)
        {
            OnFind?.Invoke(term.Trim());
            Close();
        }

        private int Levenshtein(string s, string t)
        {
            int n = s.Length, m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            for (int i = 0; i <= n; i++) d[i, 0] = i;
            for (int j = 0; j <= m; j++) d[0, j] = j;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (s[i - 1] == t[j - 1]) ? 0 : 1;
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }

            return d[n, m];
        }
    }
}
