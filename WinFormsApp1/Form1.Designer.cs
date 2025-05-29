using System.Windows.Forms;

namespace WinFormsApp1
{
    partial class Form1
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
            weaponEditor.Location = new Point(0, 0);
            weaponEditor.Name = "weaponEditor";
            weaponEditor.Size = new Size(800, 450);
            weaponEditor.TabIndex = 0;
            weaponEditor.OnFileChanged = (file_name) =>
            {
                Text = $"HMW Weapon Editor: {file_name}";
            };
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(weaponEditor);
            Name = "HMW Weapon Editor";
            Text = "HMW Weapon Editor";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion
    }
}
