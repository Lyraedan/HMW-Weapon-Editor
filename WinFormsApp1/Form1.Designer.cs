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
            this.components = new System.ComponentModel.Container();
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.weaponEditor = new WeaponEditor(); // 🔧 Instantiate it

            this.SuspendLayout();

            // 
            // weaponEditor
            // 
            this.weaponEditor.Dock = DockStyle.Fill;
            this.weaponEditor.Name = "weaponEditor";

            // 
            // Form1
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.weaponEditor); // 🔧 Add it to the form
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        #endregion
    }
}
