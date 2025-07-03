using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CARRENTAL_PROJECT
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            uc11.Hide();
            uc21.Hide();
            uc31.Hide();
            uc41.Hide();
            uc51.Hide();


        }

        private void GunaGradientButton6_Click(object sender, EventArgs e)
        {
            uc11.Visible = false;
            uc21.Visible = false;
            uc31.Visible = false;
            uc51.Visible = !uc51.Visible;
            uc41.Visible = false;

            gunaGradientButton6.Cursor = Cursors.Hand;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        private void GunaGradientButton9_Click(object sender, EventArgs e)
        {
            uc11.Visible = !uc11.Visible;
            uc21.Visible = false;
            uc31.Visible = false;
            uc51.Visible = false;
            uc41.Visible = false;

            gunaGradientButton9.Cursor = Cursors.Hand;
        }

        private void GunaGradientButton8_Click(object sender, EventArgs e)
        {
            uc11.Visible = false;
            uc21.Visible = !uc21.Visible;
            uc31.Visible = false;
            uc51.Visible = false;
            uc41.Visible = false;

            gunaGradientButton8.Cursor = Cursors.Hand;

        }

        private void GunaGradientButton7_Click(object sender, EventArgs e)
        {
            uc11.Visible = false;
            uc21.Visible = false;
            uc31.Visible = !uc31.Visible;
            uc51.Visible = false;
            uc41.Visible = false;
        }

        private void GunaGradientButton10_Click(object sender, EventArgs e)
        {
            uc11.Visible = false;
            uc21.Visible = false;
            uc31.Visible = false;
            uc51.Visible = false;
            uc41.Visible = !uc41.Visible;

            gunaGradientButton10.Cursor = Cursors.Hand;

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            uc11.Visible = false;
            uc21.Visible = false;
            uc31.Visible = false;
            uc51.Visible = false;
            uc41.Visible = false;
            
            pictureBox2.Cursor = Cursors.Hand;
        }

        private void GunaGradientButton1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void GunaGradientButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void GunaImageButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
