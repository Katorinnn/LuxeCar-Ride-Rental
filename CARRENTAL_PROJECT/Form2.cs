using System;
using System.Drawing;
using System.Windows.Forms;

namespace CARRENTAL_PROJECT
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            uc11.Hide();
            uc21.Hide();
            uc31.Hide();
            uc41.Hide();
            uc51.Hide();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            uc11.Visible = !uc11.Visible;
            uc21.Visible = false;
            uc31.Visible = false;
            uc51.Visible = false;
            uc41.Visible = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            uc11.Visible = false;
            uc21.Visible = !uc21.Visible;
            uc31.Visible = false;
            uc51.Visible = false;
            uc41.Visible = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            uc11.Visible = false;
            uc21.Visible = false;
            uc31.Visible = !uc31.Visible;
            uc51.Visible = false;
            uc41.Visible = false;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Uc31_Load(object sender, EventArgs e)
        {

        }

        private void Uc21_Load(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {


            Form1 f1 = new Form1();
            f1.Show();
            this.Close();

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            uc11.Visible = false;
            uc21.Visible = false;
            uc31.Visible = false;
            uc51.Visible = !uc51.Visible;
            uc41.Visible = false;

            //button7.Cursor = Cursors.Hand;

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            uc11.Visible = false;
            uc21.Visible = false;
            uc31.Visible = false;
            uc51.Visible = false;
            uc41.Visible = false;
        }

        private void Uc51_Load(object sender, EventArgs e)
        {

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            uc11.Visible = false;
            uc21.Visible = false;
            uc31.Visible = false;
            uc51.Visible = false;
            uc41.Visible = !uc41.Visible;
        }

        private void GunaGradientButton1_Click(object sender, EventArgs e)
        {
            uc11.Visible = false;
            uc21.Visible = false;
            uc31.Visible = false;
            uc51.Visible = !uc51.Visible;
            uc41.Visible = false;

            gunaGradientButton1.Cursor = Cursors.Hand;
        }

        private void GunaGradientButton2_Click(object sender, EventArgs e)
        {
            uc11.Visible = !uc11.Visible;
            uc21.Visible = false;
            uc31.Visible = false;
            uc51.Visible = false;
            uc41.Visible = false;

            gunaGradientButton2.Cursor = Cursors.Hand;
        }

        private void GunaGradientButton4_Click(object sender, EventArgs e)
        {
            uc11.Visible = false;
            uc21.Visible = !uc21.Visible;
            uc31.Visible = false;
            uc51.Visible = false;
            uc41.Visible = false;
        }

        private void GunaGradientButton3_Click(object sender, EventArgs e)
        {
            uc11.Visible = false;
            uc21.Visible = false;
            uc31.Visible = !uc31.Visible;
            uc51.Visible = false;
            uc41.Visible = false;
        }

        private void GunaGradientButton5_Click(object sender, EventArgs e)
        {
            uc11.Visible = false;
            uc21.Visible = false;
            uc31.Visible = false;
            uc51.Visible = false;
            uc41.Visible = !uc41.Visible;
        }

        private void uc41_Load(object sender, EventArgs e)
        {

        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        private void gunaGradientButton6_Click(object sender, EventArgs e)
        {
            uc11.Visible = false;
            uc21.Visible = false;
            uc31.Visible = false;
            uc51.Visible = !uc51.Visible;
            uc41.Visible = false;

            gunaGradientButton1.Cursor = Cursors.Hand;
        }

        private void gunaGradientButton9_Click(object sender, EventArgs e)
        {

        }

        private void gunaGradientButton8_Click(object sender, EventArgs e)
        {

        }
    }
}
