namespace Quanlyphongmach1.Presentation.Admin
{
    partial class test
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbo_ds = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbo_ds
            // 
            this.cbo_ds.FormattingEnabled = true;
            this.cbo_ds.Location = new System.Drawing.Point(127, 67);
            this.cbo_ds.Name = "cbo_ds";
            this.cbo_ds.Size = new System.Drawing.Size(252, 21);
            this.cbo_ds.TabIndex = 0;
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 269);
            this.Controls.Add(this.cbo_ds);
            this.Name = "test";
            this.Text = "test";
            this.Load += new System.EventHandler(this.test_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbo_ds;
    }
}