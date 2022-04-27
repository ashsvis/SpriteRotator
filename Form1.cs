using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SpriteRotator
{
    public partial class Form1 : Form
    {
        float angle = 180f - 133f;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                panel1.Invalidate();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                e.Graphics.ResetTransform();
                e.Graphics.TranslateTransform(-pictureBox1.Image.Width / 2f, -pictureBox1.Image.Height / 2f);
                e.Graphics.RotateTransform(angle, MatrixOrder.Append);
                e.Graphics.TranslateTransform(panel1.Width / 2f, panel1.Height / 2f, MatrixOrder.Append);
                e.Graphics.DrawImage(pictureBox1.Image, new Point(0, 0));
            }                

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Text = $"{hScrollBar1.Value}";
            angle = hScrollBar1.Value - 133;
            panel1.Invalidate();
        }
    }
}
