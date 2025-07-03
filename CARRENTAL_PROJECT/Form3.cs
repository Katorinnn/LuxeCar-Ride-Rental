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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            gunaGradient2Panel2.Width += 3;
            if (gunaGradient2Panel2.Width >= 599)
            {
                timer1.Stop();
                Form4 f4 = new Form4();
                f4.Show();
                this.Hide();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
