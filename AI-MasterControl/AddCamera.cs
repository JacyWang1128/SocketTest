using AI_MasterControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace AI_MasterControl
{
    public partial class AddCamera : Form
    {
        CameraSettings camset;
        RotateFlipType rotate;
        AddControlEventHandler add;
        TreeNode tn;
        public AddCamera(CameraSettings cameraSet, AddControlEventHandler AddControl, String captain)
        {
            InitializeComponent();
            this.camset = cameraSet;
            add = AddControl;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = captain;
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
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress ip;
            if (IPAddress.TryParse(tbIPaddress.Text, out ip))
            {
                camset.CameraIP = tbIPaddress.Text;
                camset.PreString = tbFolder.Text + @"\" + tbPreStr.Text;
                camset.IsDistinguished = cbDistinguish.Checked;
                if (!(Directory.Exists(tbFolder.Text + @"\" + @"OK\") && Directory.Exists(tbFolder.Text + @"\" + @"NG\") && Directory.Exists(tbFolder.Text + @"\WARNING\")))
                {
                    if (cbDistinguishOK.Checked)
                        Directory.CreateDirectory(tbFolder.Text + @"\" + @"OK\");
                    if (cbDistinguishNG.Checked)
                        Directory.CreateDirectory(tbFolder.Text + @"\" + @"NG\");
                    if (cbDistinguishWarning.Checked)
                        Directory.CreateDirectory(tbFolder.Text + @"\" + @"WARNING\");
                }
                camset.PreStringOK = tbFolder.Text + @"\" + @"OK\" + tbPreStr.Text;
                camset.PreStringNG = tbFolder.Text + @"\" + @"NG\" + tbPreStr.Text;
                camset.PreStringWarning = tbFolder.Text + @"\" + @"WARNING\" + tbPreStr.Text;
                try
                {
                    camset.Cmos_Width = Convert.ToInt32(tbCmosWidth.Text);
                    camset.Cmos_Heigt = Convert.ToInt32(tbCmosHeight.Text);
                    camset.ControlHeight = Convert.ToInt32(tbHeight.Text);
                    camset.ControlWidth = Convert.ToInt32(tbWidth.Text);
                    camset.ControlX = Convert.ToInt32(tbX.Text);
                    camset.ControlY = Convert.ToInt32(tbY.Text);
                    camset.Port = Convert.ToInt32(nudPort.Value);
                }
                catch (Exception)
                {
                    MessageBox.Show("请输入合理的数值", "提示");
                    return;
                }
                camset.IsAutoSaving = cbAutoSaving.Checked;
                camset.IsCameraName = cbCameraName.Checked;
                camset.IsDate = cbDate.Checked;
                camset.IsIpAddress = cbIPaddress.Checked;
                camset.IsRestore = cbRestorSize.Checked;
                camset.IsSaveNG = cbDistinguishNG.Checked;
                camset.IsSaveOK = cbDistinguishOK.Checked;
                camset.IsSaveWarning = cbDistinguishWarning.Checked;
                camset.InfoColor = pictureBox1.BackColor;
                camset.RotateType = rotate;
                this.DialogResult = DialogResult.OK;
                if (add != null)
                {
                    add.Invoke(camset);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入正确IP", "提示");
            }
        }

        private void AddCamera_Load(object sender, EventArgs e)
        {
            InitControl();
        }

        private void InitControl()
        {
            tbIPaddress.Text = camset.CameraIP;
            tbPreStr.Text = String.IsNullOrEmpty(camset.PreString) ? "" : camset.PreString.Substring(camset.PreString.LastIndexOf(@"\") + 1);
            tbFolder.Text = String.IsNullOrEmpty(camset.PreString) ? "" : camset.PreString.Substring(0, camset.PreString.LastIndexOf(@"\"));
            tbCmosWidth.Text = camset.Cmos_Width.ToString();
            tbCmosHeight.Text = camset.Cmos_Heigt.ToString();
            tbHeight.Text = camset.ControlHeight.ToString();
            tbWidth.Text = camset.ControlWidth.ToString();
            tbX.Text = camset.ControlX.ToString();
            tbY.Text = camset.ControlY.ToString();
            tbCmosHeight.Text = camset.Cmos_Heigt.ToString();
            cbAutoSaving.Checked = camset.IsAutoSaving;
            cbCameraName.Checked = camset.IsCameraName;
            cbDate.Checked = camset.IsDate;
            cbIPaddress.Checked = camset.IsIpAddress;
            cbRestorSize.Checked = camset.IsRestore;
            cbDistinguish.Checked = camset.IsDistinguished;
            cbDistinguishNG.Checked = camset.IsSaveNG;
            cbDistinguishOK.Checked = camset.IsSaveOK;
            cbDistinguishWarning.Checked = camset.IsSaveWarning;
            nudPort.Value = camset.Port;
            pictureBox1.BackColor = camset.InfoColor;
            switch (camset.RotateType)
            {
                case RotateFlipType.RotateNoneFlipNone:
                    radioButton4.Checked = true;
                    break;
                case RotateFlipType.Rotate90FlipNone:
                    radioButton1.Checked = true;
                    break;
                case RotateFlipType.Rotate180FlipNone:
                    radioButton2.Checked = true;
                    break;
                case RotateFlipType.Rotate270FlipNone:
                    radioButton3.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void SetRotate(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                rotate = 0;
            }
            if (radioButton1.Checked)
            {
                rotate = RotateFlipType.Rotate90FlipNone;
            }
            if (radioButton2.Checked)
            {
                rotate = RotateFlipType.Rotate180FlipNone;
            }
            if (radioButton3.Checked)
            {
                rotate = RotateFlipType.Rotate270FlipNone;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btSelectColor_Click(object sender, EventArgs e)
        {
            ColorDialog cld = new ColorDialog();
            if (DialogResult.OK == cld.ShowDialog())
            {
                pictureBox1.BackColor = cld.Color;
            }
        }
    }
}
