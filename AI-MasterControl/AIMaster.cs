using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace AI_MasterControl
{
    public delegate void MessageHandle(Dictionary<String, String> dic);
    public partial class AIMaster : UserControl
    {
        MessageHandle msgh;
        VCZcamera camera;
        String configPath;
        private Int32 Original_Width;
        private Int32 Original_Height;
        public AIMaster()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void ShowInfo(Dictionary<String, String> Info)
        {
            lbBadCount.Text = Info["BadCount"];
            lbGoodCount.Text = Info["GoodCount"];
            lbCycleTime.Text = Info["CycleTime"];
            lbCameraIP.Text = Info["CameraIP"];
            lbCameraName.Text = Info["CameraName"];
            lbRoiheight.Text = Info["Roi_height"];
            lbRoiwidth.Text = Info["Roi_width"];
            lbRoix.Text = Info["Roi_x"];
            lbRoiy.Text = Info["Roi_y"];
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            msgh = new MessageHandle(ShowInfo);
            camera = new VCZcamera(msgh, pictureBox1);
            panel1.Visible = false;
            panel2.Visible = false;
            panel1.BackColor = Color.FromArgb(8, Color.LightGreen);
            panel2.BackColor = Color.FromArgb(8, Color.LightGreen);
            Original_Height = this.Height;
            Original_Width = this.Width;
        }

        private void btStartListening_Click(object sender, EventArgs e)
        {
            if (camera.isReceiving)
            {
                camera.Stop();
                btStartListening.Text = "开始监听";
            }
            else
            {
                IPAddress addr;
                if (IPAddress.TryParse(tbIPaddress.Text, out addr))
                {
                    camera.CameraIP = addr.ToString();
                    camera.Port = Convert.ToInt32(nudPort.Value);
                    camera.Start();
                    btStartListening.Text = "结束监听";
                }
                else
                {
                    MessageBox.Show("请输入合法IP地址！");
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            camera.Stop();
        }

        private void SetRotate(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                camera.rotate = 0;
            }
            if (radioButton1.Checked)
            {
                camera.rotate = RotateFlipType.Rotate90FlipNone;
            }
            if (radioButton2.Checked)
            {
                camera.rotate = RotateFlipType.Rotate180FlipNone;
            }
            if (radioButton3.Checked)
            {
                camera.rotate = RotateFlipType.Rotate270FlipNone;
            }
        }

        private void btSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "请选择文件夹";
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.ShowNewFolderButton = true;
            if (DialogResult.OK == fbd.ShowDialog())
            {
                tbFolder.Text = fbd.SelectedPath;
                SetFilePreFile();
            }
        }

        public void SetFilePreFile()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(tbFolder.Text + @"\");
            sb.Append(textBox3.Text);
            if (cbIPaddress.Checked)
            {
                sb.Append(lbCameraIP.Text.Replace(".", "_"));
            }
            if (cbCameraName.Checked)
            {
                sb.Append(lbCameraName.Text.Replace(".", "_"));
            }
            if (cbDate.Checked)
            {
                sb.Append(DateTime.Now.ToString("yyyy-MM-dd"));
            }
            camera.FilePrefix = sb.ToString();
        }

        private void SaveInfoChecked(object sender, EventArgs e)
        {
            SetFilePreFile();
        }

        private void cbAutoSaving_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutoSaving.Checked)
            {
                SetFilePreFile();
                camera.IsSaveing = true;
            }
            else
            {
                camera.IsSaveing = false;
            }
        }

        private void cbRestorSize_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbRestorSize.Checked)
                {
                    camera.SetCMOS(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                    camera.IsRestore = true;
                }
                else
                {
                    camera.IsRestore = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            tbFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            cbAutoSaving.Checked = false;
        }

        Point mousePoint;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseButtons whichButton = (e as MouseEventArgs).Button;
            switch (whichButton)
            {
                case MouseButtons.Left:
                    isSelected = !isSelected;
                    pictureBox1.Refresh();
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Right:
                    //mousePoint = (e as MouseEventArgs).Location;
                    mousePoint = new Point((e as MouseEventArgs).X + this.Parent.Location.X, (e as MouseEventArgs).Y + this.Parent.Location.Y);
                    contextMenuStrip1.Show(mousePoint);
                    break;
                case MouseButtons.Middle:
                    break;
                case MouseButtons.XButton1:
                    break;
                case MouseButtons.XButton2:
                    break;
                default:
                    break;
            }
            panel2.Visible = false;
        }

        public Boolean IsOverShow(Rectangle controlClientRectangle, Point location)
        {
            return controlClientRectangle.Contains(location);
        }

        private void 相机设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsOverShow(this.ClientRectangle, new Point(mousePoint.X + panel2.Width, mousePoint.Y + panel2.Height)))
            {
                panel2.Location = mousePoint;
            }
            else
            {
                panel2.Location = new Point(this.Width / 3, this.Height / 3);
            }
            Animation.ShowControl(panel2, true, AnchorStyles.Bottom);
        }

        private void 相机信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                Animation.ShowControl(panel1, false, AnchorStyles.Top);
            }
            else
            {
                if (IsOverShow(this.ClientRectangle, new Point(mousePoint.X + panel1.Width, mousePoint.Y + panel1.Height)))
                {
                    panel1.Location = mousePoint;
                }
                else
                {
                    panel1.Location = new Point(this.Width / 3, this.Height / 3);
                }
                Animation.ShowControl(panel1, true, AnchorStyles.Top);
            }
        }
        private void AIMaster_Resize(object sender, EventArgs e)
        {
            if (Original_Width > 0 || Original_Height > 0)
            {
                Int32 Original_X = panel2.Location.X;
                Int32 Original_Y = panel2.Location.Y;
                Int32 Current_Width = this.Width;
                double Proportion = (double)Current_Width / (double)Original_Width;
                panel2.Location = new Point(Convert.ToInt32(Original_X * Proportion), Convert.ToInt32(Original_Y * Proportion));
                Original_X = panel1.Location.X;
                Original_Y = panel1.Location.Y;
                panel1.Location = new Point(Convert.ToInt32(Original_X * Proportion), Convert.ToInt32(Original_Y * Proportion));
            }
        }
        Boolean isSelected = false;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (isSelected)
            {
                PictureBox p = (PictureBox)sender;
                Pen pp = new Pen(Color.Red);
                e.Graphics.DrawRectangle(pp, e.ClipRectangle.X,
                e.ClipRectangle.Y,
                e.ClipRectangle.X + e.ClipRectangle.Width - 1,
                e.ClipRectangle.Y + e.ClipRectangle.Height - 1);
            }
        }
    }
}
