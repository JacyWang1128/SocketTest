using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AI_Master_SharedMemory
{
    public partial class AddWindow : Form
    {
        //picturebox属性信息poco
        DisplayPictureboxInfo pbInfo;

        public AddWindow(DisplayPictureboxInfo dpi)
        {
            InitializeComponent();
            pbInfo = dpi;
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                pbInfo.Index = (Int32)nudPort.Value;
                pbInfo.X = Convert.ToInt32(tbX.Text);
                pbInfo.Y = Convert.ToInt32(tbY.Text);
                pbInfo.Width = Convert.ToInt32(tbWidth.Text);
                pbInfo.Height = Convert.ToInt32(tbHeight.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确的数值！");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddWindow_Load(object sender, EventArgs e)
        {
            nudPort.Value = pbInfo.Index;
            tbX.Text = pbInfo.X.ToString();
            tbY.Text = pbInfo.Y.ToString();
            tbWidth.Text = pbInfo.Width.ToString();
            tbHeight.Text = pbInfo.Height.ToString();
        }
    }
}
