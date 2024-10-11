using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeScanner2
{
    public partial class Form1 : Form
    {
        VideoCapture vc;
        VideoWriter vw = new VideoWriter();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            try
            {
                vc = new VideoCapture(1);  // internal web cam
                                           // For another,
                                           // vc=new VideoCapture(string.Format("http://192.168.0.23:8090/?action=stream"); 

            }
            catch { }

            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Mat frame = new Mat();
            vc.Read(frame);
            if (frame.Empty()) return;
            else
            {
                try
                {
                    this.Invoke((Action)(() =>
                    {
                        vw.Write(frame);
                        pictureBox1.Image = BitmapConverter.ToBitmap(frame);

                    }), null);
                }
                catch { }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
