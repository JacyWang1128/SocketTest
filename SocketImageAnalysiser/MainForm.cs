using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SocketImageAnalysiser
{
    public partial class MainForm : Form
    {
        MessageHandle msgh;
        VCZcamera camera;
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.StartPosition = FormStartPosition.CenterScreen;
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
            camera = new VCZcamera(msgh,pictureBox1);
        }

        private void btStartListening_Click(object sender, EventArgs e)
        {
            if (camera.isReceiving)
            {
                MessageBox.Show("监听正在进行！");
            }
            else
            {
                camera.Start(Convert.ToInt32(nudPort.Value));
            }
        }

        private void btStopListening_Click(object sender, EventArgs e)
        {
            if (camera.isReceiving)
            {
                camera.Stop();
            }
            else
            {
                MessageBox.Show("监听已经停止！");
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            //if (panel2.Visible)
            //    panel2.Visible = false;
            //else
            //    Animation.ShowControl(panel2, true, AnchorStyles.Top);
        }
    }
}
