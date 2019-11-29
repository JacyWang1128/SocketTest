using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TcpTest
{
    public partial class Form1 : Form
    {
        AI_MasterControl.WriteParameter wp;
        public Form1()
        {
            InitializeComponent();
            wp = new AI_MasterControl.WriteParameter("192.168.3.17");
            wp.Dock = DockStyle.Fill;
            this.Controls.Add(wp);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            wp.myTcp.connect("192.168.3.17", 5953);
        }
    }
}
