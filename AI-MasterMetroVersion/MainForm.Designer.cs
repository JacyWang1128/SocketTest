namespace AI_MasterMetroVersion
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.plLeft = new System.Windows.Forms.Panel();
            this.plMiddle = new System.Windows.Forms.Panel();
            this.plBottom = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ilTreeViewIconList = new System.Windows.Forms.ImageList(this.components);
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.plLeftTop = new System.Windows.Forms.Panel();
            this.plLeftMiddle = new System.Windows.Forms.Panel();
            this.plLeft.SuspendLayout();
            this.plLeftTop.SuspendLayout();
            this.plLeftMiddle.SuspendLayout();
            this.SuspendLayout();
            // 
            // plLeft
            // 
            this.plLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.plLeft.Controls.Add(this.plLeftMiddle);
            this.plLeft.Controls.Add(this.plLeftTop);
            this.plLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.plLeft.Location = new System.Drawing.Point(20, 60);
            this.plLeft.Name = "plLeft";
            this.plLeft.Size = new System.Drawing.Size(200, 880);
            this.plLeft.TabIndex = 0;
            // 
            // plMiddle
            // 
            this.plMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.plMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMiddle.Location = new System.Drawing.Point(220, 60);
            this.plMiddle.Name = "plMiddle";
            this.plMiddle.Size = new System.Drawing.Size(1040, 880);
            this.plMiddle.TabIndex = 0;
            // 
            // plBottom
            // 
            this.plBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.plBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plBottom.Location = new System.Drawing.Point(220, 754);
            this.plBottom.Name = "plBottom";
            this.plBottom.Size = new System.Drawing.Size(1040, 186);
            this.plBottom.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(200, 824);
            this.treeView1.TabIndex = 2;
            // 
            // ilTreeViewIconList
            // 
            this.ilTreeViewIconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeViewIconList.ImageStream")));
            this.ilTreeViewIconList.TransparentColor = System.Drawing.Color.Transparent;
            this.ilTreeViewIconList.Images.SetKeyName(0, "Camera");
            // 
            // metroLabel1
            // 
            this.metroLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroLabel1.Location = new System.Drawing.Point(0, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(200, 56);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "相机列表";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // plLeftTop
            // 
            this.plLeftTop.Controls.Add(this.metroLabel1);
            this.plLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.plLeftTop.Location = new System.Drawing.Point(0, 0);
            this.plLeftTop.Name = "plLeftTop";
            this.plLeftTop.Size = new System.Drawing.Size(200, 56);
            this.plLeftTop.TabIndex = 4;
            // 
            // plLeftMiddle
            // 
            this.plLeftMiddle.Controls.Add(this.treeView1);
            this.plLeftMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plLeftMiddle.Location = new System.Drawing.Point(0, 56);
            this.plLeftMiddle.Name = "plLeftMiddle";
            this.plLeftMiddle.Size = new System.Drawing.Size(200, 824);
            this.plLeftMiddle.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 960);
            this.Controls.Add(this.plBottom);
            this.Controls.Add(this.plMiddle);
            this.Controls.Add(this.plLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "AI-Master";
            this.plLeft.ResumeLayout(false);
            this.plLeftTop.ResumeLayout(false);
            this.plLeftMiddle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plLeft;
        private System.Windows.Forms.Panel plMiddle;
        private System.Windows.Forms.Panel plBottom;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList ilTreeViewIconList;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.Panel plLeftTop;
        private System.Windows.Forms.Panel plLeftMiddle;
    }
}

