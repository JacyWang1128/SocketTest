using AI_MasterControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AI_Master
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AIMaster ai = new AIMaster();
            plMiddle.Controls.Add(ai);
            ai.camera.camInfo.BadCount = ai.Width.ToString();
            dataGridView1.DataSource = ai.camera.camInfo;
        }
    }
}
