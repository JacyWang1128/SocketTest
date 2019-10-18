using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SocketImageAnalysiser
{
    public partial class MainForm : Form
    {
        MessageHandle msgh;
        VCZcamera camera;
        String configPath;
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
            //lbImgFormat.Text = Info["format"];
            //lbImgHeight.Text = Info["ImgHeight"];
            //lbImgWidth.Text = Info["ImgWidth"];
            //lbImgSection.Text = Info["ImgSection"];
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
                camera.Stop();
                btStartListening.Text = "开始监听";
            }
            else
            {
                camera.Start(Convert.ToInt32(nudPort.Value));
                btStartListening.Text = "结束监听";
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
            if(DialogResult.OK == fbd.ShowDialog())
            {
                tbFolder.Text = fbd.SelectedPath;
                SetFilePreFile();
            }
        }

        public void SetFilePreFile()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(tbFolder.Text + @"\");
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
            sb.Append(textBox3.Text);
            camera.FilePrefix = sb.ToString();
        }

        private void SaveInfoChecked(object sender,EventArgs e)
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
            //configPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\EyeView\";
            //if (Directory.Exists(configPath))
            //{
            //    if (File.Exists(configPath + @"Application.config"))
            //    {
            //        using(FileStream fs = new FileStream(configPath + @"Application.config", FileMode.Open, FileAccess.Read))
            //        {
            //            using(StreamReader sw = new StreamReader(fs))
            //            {
            //                String res = sw.ReadToEnd();
            //                if (res.Contains("SaveFolder="))
            //                {
            //                    Int32 offset = res.IndexOf("SaveFolder=") + "SaveFolder=".Length;
            //                    String temp = res.Substring(offset);
            //                    Int32 targetIndex = temp.IndexOf(";");
            //                    String path = temp.Substring(0, targetIndex + 1);
            //                    tbFolder.Text = path;
            //                }
            //                else
            //                {
            //                    tbFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {
            //        File.Create(configPath + @"Application.config");
            //        tbFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //    }
            //}
            //else
            //{
            //    Directory.CreateDirectory(configPath);
            //}
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            cbAutoSaving.Checked = false;
        }
    }
}
