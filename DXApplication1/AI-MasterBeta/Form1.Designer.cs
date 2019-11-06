namespace AI_MasterBeta
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
            this.plTop = new System.Windows.Forms.Panel();
            this.plLeft = new System.Windows.Forms.Panel();
            this.plRight = new System.Windows.Forms.Panel();
            this.plBottom = new System.Windows.Forms.Panel();
            this.plMiddle = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // plTop
            // 
            this.plTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.plTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTop.Location = new System.Drawing.Point(0, 0);
            this.plTop.Name = "plTop";
            this.plTop.Size = new System.Drawing.Size(1584, 100);
            this.plTop.TabIndex = 0;
            // 
            // plLeft
            // 
            this.plLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.plLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.plLeft.Location = new System.Drawing.Point(0, 100);
            this.plLeft.Name = "plLeft";
            this.plLeft.Size = new System.Drawing.Size(200, 629);
            this.plLeft.TabIndex = 1;
            // 
            // plRight
            // 
            this.plRight.BackColor = System.Drawing.Color.Olive;
            this.plRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.plRight.Location = new System.Drawing.Point(1384, 100);
            this.plRight.Name = "plRight";
            this.plRight.Size = new System.Drawing.Size(200, 629);
            this.plRight.TabIndex = 2;
            // 
            // plBottom
            // 
            this.plBottom.AutoScroll = true;
            this.plBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.plBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plBottom.Location = new System.Drawing.Point(200, 629);
            this.plBottom.Name = "plBottom";
            this.plBottom.Size = new System.Drawing.Size(1184, 100);
            this.plBottom.TabIndex = 3;
            // 
            // plMiddle
            // 
            this.plMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.plMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMiddle.Location = new System.Drawing.Point(200, 100);
            this.plMiddle.Name = "plMiddle";
            this.plMiddle.Size = new System.Drawing.Size(1184, 529);
            this.plMiddle.TabIndex = 4;
            // 
            // MainForm
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1584, 729);
            this.Controls.Add(this.plMiddle);
            this.Controls.Add(this.plBottom);
            this.Controls.Add(this.plRight);
            this.Controls.Add(this.plLeft);
            this.Controls.Add(this.plTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinMaskColor = System.Drawing.Color.Aqua;
            this.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Red;
            this.LookAndFeel.SkinName = "Pumpkin";
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.Name = "MainForm";
            this.Text = "AI-Master";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plTop;
        private System.Windows.Forms.Panel plLeft;
        private System.Windows.Forms.Panel plRight;
        private System.Windows.Forms.Panel plBottom;
        private System.Windows.Forms.Panel plMiddle;
    }
}

