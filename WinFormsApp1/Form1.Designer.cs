using System;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    partial class Form1 : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // 🔧 Add the WeaponEditor field
        private WeaponEditor weaponEditor;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            weaponEditor = new WeaponEditor();
            SuspendLayout();
            // 
            // weaponEditor
            // 
            weaponEditor.AllowDrop = true;
            weaponEditor.Dock = DockStyle.Fill;
            weaponEditor.Location = new System.Drawing.Point(0, 0);
            weaponEditor.Name = "weaponEditor";
            weaponEditor.Size = new System.Drawing.Size(800, 450);
            weaponEditor.TabIndex = 0;
            weaponEditor.OnFileChanged = (file_name) =>
            {
                Text = $"HMW Weapon Editor: {file_name}";
            };
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(weaponEditor);
            Name = "Form1";
            Text = "HMW Weapon Editor";

            // Subscribe to the FormClosing event here
            this.FormClosing += Form1_FormClosing;

            ResumeLayout(false);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var unsavedTabs = weaponEditor.GetDirtyTabs().ToList();
            if (unsavedTabs.Count > 0)
            {
                var result = MessageBox.Show(
                    "There are unsaved changes. Do you want to save before exiting?",
                    "Unsaved Changes",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    foreach (var tab in unsavedTabs)
                    {
                        weaponEditor.SelectTab(tab);
                        weaponEditor.SaveCurrentFile();
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                // If No, just exit without saving
            }
        }
    }
    #endregion
}