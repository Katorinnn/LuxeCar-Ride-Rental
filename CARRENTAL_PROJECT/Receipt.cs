using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CARRENTAL_PROJECT
{
    public partial class Receipt : Form
    {
       

        public Receipt()
        {
            InitializeComponent();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Receipt_Load(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {



        }

            private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == 13)
                {
                    string connection = "server=localhost;user id=root;password=;database=carrental";
                    string query = "SELECT * FROM tbl_rental WHERE RENTID='" + textBox1.Text + "'";
                    MySqlConnection conn = new MySqlConnection(connection);
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader dr;
                    conn.Open();
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        label1.Text = dr["CUSTOMERNAME"].ToString();
                        label2.Text = dr["PRICE"].ToString();
                        label3.Text = dr["RENTDATE"].ToString();
                        label4.Text = dr["RETURNDATE"].ToString();
                        label5.Text = dr["CARID"].ToString();
                       


                }

                    else
                    {
                        MessageBox.Show("RENT ID Not Found");
                    }
                    conn.Close();
                }
            }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btndisplay_Click(object sender, EventArgs e)
        {
            txtreceipt.Clear();
            txtreceipt.Text += "\n\n";
            txtreceipt.Text += "\n\n";
            txtreceipt.Text += "                               LUXCAR RIDE RENTAL "+"\n\n";
            txtreceipt.Text += "                           Flexible.Accesible.Affordable" + "\n\n";
            txtreceipt.Text += "\n\n";
            txtreceipt.Text += "\n\n\n";
            txtreceipt.Text +=  "   Date: "+DateTime.Now +"                          Type: Cash"+"\n\n";
            txtreceipt.Text += "    Client:  " + label1.Text + "\n\n" + "";
            txtreceipt.Text += " ------------------------------------------------------------------------------------------------"+"\n";
            txtreceipt.Text += "     Cars                                                                       Price"+"\n";
            txtreceipt.Text += " ------------------------------------------------------------------------------------------------" + "\n";
            txtreceipt.Text += "    "+label5.Text + "                                               "+ label2.Text +".00"+"\n\n";
           
            txtreceipt.Text += "    RentDate:" + label3.Text + "\n\n";
            txtreceipt.Text += "    ReturnDate:" + label4.Text + "\n\n";
            txtreceipt.Text += " ------------------------------------------------------------------------------------------------" + "\n\n";
           
            txtreceipt.Text += "                                           Total Amount                 "+label2.Text+".00";
            txtreceipt.Text += "\n\n\n\n";
            txtreceipt.Text += " ------------------------------------------------------------------------------------------------" + "\n";
            txtreceipt.Text += "                                   LuxCar Ride Rental" + "\n";
            txtreceipt.Text += "                    You will be satisfied with our guarantee"+"\n";
            txtreceipt.Text += "                             Flexible.Accesible.Affordable" + "\n";
            txtreceipt.Text += " ------------------------------------------------------------------------------------------------" + "\n";
            txtreceipt.Text += "                             Biga 1, Silang, Cavite 4118 \n " +                                   
                               "                               6XRH+8F Silang, Cavite \n"+
                               "                                    (046) 513 5706 \n";
            txtreceipt.Text += " ------------------------------------------------------------------------------------------------" + "\n";
            txtreceipt.Text += "                 *** THIS IS YOUR OFFICIAL RECEIPT***";
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(txtreceipt.Text, new Font("Microsoft Sans", 8, FontStyle.Bold), Brushes.Black, new Point(10, 10));
            

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 350, 700);
            printPreviewDialog1.ShowDialog();

        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 350, 700);
            printPreviewDialog1.ShowDialog();
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            txtreceipt.Clear();
            txtreceipt.Text += "\n\n";
            txtreceipt.Text += "\n\n";
            txtreceipt.Text += "                               LUXCAR RIDE RENTAL " + "\n\n";
            txtreceipt.Text += "                           Flexible.Accesible.Affordable" + "\n\n";
            txtreceipt.Text += "\n\n";
            txtreceipt.Text += "\n\n\n";
            txtreceipt.Text += "   Date: " + DateTime.Now + "                          Type: Cash" + "\n\n";
            txtreceipt.Text += "    Client:  " + label1.Text + "\n\n" + "";
            txtreceipt.Text += " ------------------------------------------------------------------------------------------------" + "\n";
            txtreceipt.Text += "     Cars                                                                       Price" + "\n";
            txtreceipt.Text += " ------------------------------------------------------------------------------------------------" + "\n";
            txtreceipt.Text += "    " + label5.Text + "                                               " + label2.Text + ".00" + "\n\n";

            txtreceipt.Text += "    RentDate:" + label3.Text + "\n\n";
            txtreceipt.Text += "    ReturnDate:" + label4.Text + "\n\n";
            txtreceipt.Text += " ------------------------------------------------------------------------------------------------" + "\n\n";

            txtreceipt.Text += "                                           Total Amount                 " + label2.Text + ".00";
            txtreceipt.Text += "\n\n\n\n";
            txtreceipt.Text += " ------------------------------------------------------------------------------------------------" + "\n";
            txtreceipt.Text += "                                   LuxCar Ride Rental" + "\n";
            txtreceipt.Text += "                    You will be satisfied with our guarantee" + "\n";
            txtreceipt.Text += "                             Flexible.Accesible.Affordable" + "\n";
            txtreceipt.Text += " ------------------------------------------------------------------------------------------------" + "\n";
            txtreceipt.Text += "                             Biga 1, Silang, Cavite 4118 \n " +
                               "                               6XRH+8F Silang, Cavite \n" +
                               "                                    (046) 513 5706 \n";
            txtreceipt.Text += " ------------------------------------------------------------------------------------------------" + "\n";
            txtreceipt.Text += "                 *** THIS IS YOUR OFFICIAL RECEIPT***";
        }
    }
}
