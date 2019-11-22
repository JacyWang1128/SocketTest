using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SocketTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Image img = Image.FromFile(@"C:\Users\Administrator\Desktop\转换\圣地——可汗山（张元刚） - 副本 (6)0.jpg");
            Bitmap bmp = new Bitmap(img);
            img.Dispose();
            bmp.Save(@"C:\Users\Administrator\Desktop\wjy2dy\2133.jpg");
        }
    }
}
