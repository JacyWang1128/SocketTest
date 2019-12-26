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
            //wp = new AI_MasterControl.WriteParameter("192.168.3.17");
            //wp.Dock = DockStyle.Fill;
            //this.Controls.Add(wp);
            pictureBox1.Image = Image.FromFile(@"C:\Users\wangj\Desktop\guangqisuo\background1.jpg");
            pictureBox2.Image = Image.FromFile(@"C:\Users\wangj\Desktop\guangqisuo\backgrounds.jpg");
            pictureBox1.MouseWheel += new MouseEventHandler(pictureBox1_MouseWheel);
            pictureBox2.MouseWheel += new MouseEventHandler(pictureBox1_MouseWheel);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //wp.myTcp.connect("192.168.3.17", 5953);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.DarkGray);
                g.DrawArc(new Pen(Color.Red), new Rectangle(10, 10, 20, 20), 0, 270);
            }
            pictureBox1.Image = bmp;
        }

        Boolean isPress = false;
        Int32 x, y;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPress = true;
                x = e.X;
                y = e.Y;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isPress = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPress)
            {
                Int32 x0 = (sender as Control).Location.X;
                Int32 y0 = (sender as Control).Location.Y;
                (sender as Control).Location = new Point(x0 + (e.X - x), y0 + (e.Y - y));
            }
        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            Size size = (sender as Control).Size;
            Int32 x = e.Delta;
            if (x > 0)
            {
                size.Width = (Int32)(size.Width * 1.05);
                size.Height = (Int32)(size.Height * 1.05);
            }
            else
            {
                size.Width = (Int32)(size.Width / 1.05);
                size.Height = (Int32)(size.Height / 1.05);
            }
            if (size.Height < (sender as Control).Parent.Height)
                (sender as Control).Size = size;

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    break;
                case MouseButtons.Middle:
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Right:
                    break;
                case MouseButtons.XButton1:
                    break;
                case MouseButtons.XButton2:
                    break;
                default:
                    break;
            }
        }
    }
}
