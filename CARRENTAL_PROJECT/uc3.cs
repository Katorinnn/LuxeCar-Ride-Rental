using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CARRENTAL_PROJECT
{
    public partial class uc3 : UserControl
    {
        MySqlDataAdapter adapt;
        private Timer refreshTimer;

        public uc3()
        {
            InitializeComponent();

            refreshTimer = new Timer();
            refreshTimer.Interval = 10000; // Set the interval in milliseconds (e.g., 5000ms = 5 seconds)
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();


        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            {
                string connection = "server=localhost;user id=root;password=;database=carrental";

                // Check if any of the input fields is empty
                if (string.IsNullOrWhiteSpace(this.txtcarid.Text) || string.IsNullOrWhiteSpace(this.txtcustomerid.Text) || string.IsNullOrWhiteSpace(this.txtcustomername.Text) || string.IsNullOrWhiteSpace(this.txtprice.Text) || string.IsNullOrWhiteSpace(this.txtrent.Text) || string.IsNullOrWhiteSpace(this.txtreturn.Text) || string.IsNullOrWhiteSpace(this.txtcarid.Text))
                {
                    MessageBox.Show("Please fill in all the fields before saving.");
                }
                else
                {
                    string rentalQuery = "INSERT INTO tbl_rental(CARID,CUSTOMERID,CUSTOMERNAME,PRICE,RENTDATE,RETURNDATE)VALUES('" + this.txtcarid.Text + "','" + this.txtcustomerid.Text + "','" + this.txtcustomername.Text + "','" + this.txtprice.Text + "  " + this.txtcarid.Text + "', '" + this.txtrent.Text + "', '" + this.txtreturn.Text + "')";

                    string updateCarStatusQuery = "UPDATE tbl_cars SET STATUS = 'BOOKED' WHERE REGNO = '" + this.txtcarid.Text + "' AND STATUS = 'AVAILABLE'";

                    MySqlConnection conn = new MySqlConnection(connection);
                    MySqlCommand rentalCmd = new MySqlCommand(rentalQuery, conn);
                    MySqlCommand updateCarStatusCmd = new MySqlCommand(updateCarStatusQuery, conn);

                    MySqlDataReader dr;
                    conn.Open();

                    // Execute the rental query
                    dr = rentalCmd.ExecuteReader();
                    dr.Close();

                    // Execute the update query for tbl_cars
                    updateCarStatusCmd.ExecuteNonQuery();

                    MessageBox.Show("Successfully Saved");

                    conn.Close();
                }
                btnadd.Cursor = Cursors.Hand;
                DisplayData();


            }



        }

        private void btnreset_Click(object sender, EventArgs e)
        {
          
        }

        private void DisplayData()
        {
            string connection = "server=localhost;user id=root;password=;database=carrental";
            string query = "SELECT * FROM tbl_rental";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void uc3_Load(object sender, EventArgs e)
        {
           RefreshData();
            DisplayData();

        }

        private void RefreshData()
        {
          
            string connection = "server=localhost;user id=root;password=;database=carrental";
            string query = "SELECT * FROM tbl_cars";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string reg = dr["REGNO"].ToString();
                string brand = dr["BRAND"].ToString();
                string model = dr["MODEL"].ToString();

                // Assuming you have two tables and you want to concatenate BRAND and MODEL
                string combinedText = $"{reg} {brand} {model}";

                txtcarid.Items.Add(combinedText);



            }
            conn.Close();
        
    }
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
           DisplayData();
        }


        public void carload()
        {
            
        }

        private void txtcarid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connection = "server=localhost;user id=root;password=;database=carrental";
            string query = "SELECT * FROM tbl_cars WHERE REGNO='"+txtcarid.Text+"'";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                string aval;


                aval = (dr["STATUS"].ToString());

                label7.Text = aval;
                
                if(aval =="BOOKED")
                {
                    txtcustomerid.Enabled = false;
                    txtcustomername.Enabled = false;
                    txtprice.Enabled = false;
                    txtrent.Enabled = false;
                    txtreturn.Enabled = false;
                }

                else
                {
                    txtcustomerid.Enabled = true;
                    txtcustomername.Enabled = true;
                    txtprice.Enabled = true;
                    txtrent.Enabled = true;
                    txtreturn.Enabled = true;
                }
            }
            else
            {
                label7.Text = "AVAILABLE";
            }
            conn.Close();
        }

        private void txtcustomerid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                string connection = "server=localhost;user id=root;password=;database=carrental";
                string query = "SELECT * FROM tbl_customer WHERE CUSTOMERID='" + txtcustomerid.Text + "'";
                MySqlConnection conn = new MySqlConnection(connection);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dr;
                conn.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    string name = dr["CUSTOMERNAME"].ToString();
                    string phone = dr["CONTACT"].ToString();

                    // Assuming you have two tables and you want to concatenate CUSTOMERNAME and CONTACT
                    string combinedText = $"{name} / {phone}";


                    txtcustomername.Text = combinedText;
                }
                else
                {
                    MessageBox.Show("Customer ID Not Found");
                }
                conn.Close();

                }
        }

        private void txtcustomerid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string connection = "server=localhost;user id=root;password=;database=carrental";
            string query = "SELECT * FROM tbl_cars";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            txtcarid.Text = row.Cells[1].Value.ToString();
            txtcustomerid.Text = row.Cells[2].Value.ToString();
            txtcustomername.Text = row.Cells[3].Value.ToString();
            txtprice.Text = row.Cells[4].Value.ToString();
             

          
        }

        private void txtcustomername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnload_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost;user id=root;password=;database=carrental";
            string query = "SELECT * FROM tbl_rental";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Receipt r1 = new Receipt();
            r1.Show();

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void returnc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtrent_ValueChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Receipt r1 = new Receipt();
            r1.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtreturn_ValueChanged(object sender, EventArgs e)
        {

        }
    }
    
}
