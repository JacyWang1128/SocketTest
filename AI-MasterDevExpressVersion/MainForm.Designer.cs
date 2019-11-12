namespace AI_MasterDevExpressVersion
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.plLeft = new DevExpress.XtraEditors.SidePanel();
            this.plBottom = new DevExpress.XtraEditors.SidePanel();
            this.plMiddle = new DevExpress.XtraEditors.SidePanel();
            this.SuspendLayout();
            // 
            // plLeft
            // 
            this.plLeft.BorderThickness = 0;
            this.plLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.plLeft.Location = new System.Drawing.Point(0, 0);
            this.plLeft.Name = "plLeft";
            this.plLeft.Size = new System.Drawing.Size(118, 441);
            this.plLeft.TabIndex = 0;
            this.plLeft.Text = "sidePanel1";
            // 
            // plBottom
            // 
            this.plBottom.BorderThickness = 0;
            this.plBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plBottom.Location = new System.Drawing.Point(118, 333);
            this.plBottom.Name = "plBottom";
            this.plBottom.Size = new System.Drawing.Size(506, 108);
            this.plBottom.TabIndex = 0;
            this.plBottom.Text = "sidePanel1";
            // 
            // plMiddle
            // 
            this.plMiddle.BorderThickness = 0;
            this.plMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMiddle.Location = new System.Drawing.Point(118, 0);
            this.plMiddle.Name = "plMiddle";
            this.plMiddle.Size = new System.Drawing.Size(506, 333);
            this.plMiddle.TabIndex = 0;
            this.plMiddle.Text = "sidePanel1";
            // 
            // MainForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.plMiddle);
            this.Controls.Add(this.plBottom);
            this.Controls.Add(this.plLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SidePanel plLeft;
        private DevExpress.XtraEditors.SidePanel plBottom;
        private DevExpress.XtraEditors.SidePanel plMiddle;
    }
}

