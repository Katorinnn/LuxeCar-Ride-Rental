using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CARRENTAL_PROJECT
{
    public partial class uc4 : UserControl
    {
        MySqlDataAdapter adapt;
        private Timer refreshTimer;
        public uc4()
        {
            InitializeComponent();
            refreshTimer = new Timer();
            refreshTimer.Interval = 5000; // Set the interval in milliseconds (e.g., 5000ms = 5 seconds)
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }

        private void btnreturn_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionStr = "server=localhost;user id=root;password=;database=carrental";

                // Check if any of the input fields is empty
                if (string.IsNullOrWhiteSpace(returnc.Text) || string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(Date.Text))
                {
                    MessageBox.Show("Please fill in all the fields before saving.");
                }
                else
                {
                    // Insert into tbl_return
                    using (MySqlConnection connInsert = new MySqlConnection(connectionStr))
                    {
                        connInsert.Open();
                        string insertQuery = "INSERT INTO tbl_return(CARID, CUSTOMERNAME, DATE) VALUES(@carId, @customerName, @returnDate)";
                        using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connInsert))
                        {
                            insertCmd.Parameters.AddWithValue("@carId", returnc.Text);
                            insertCmd.Parameters.AddWithValue("@customerName", textBox1.Text);
                            insertCmd.Parameters.AddWithValue("@returnDate", Date.Text);

                            insertCmd.ExecuteNonQuery();
                            MessageBox.Show("Return Car Saved");
                        }
                    }

                    // Update tbl_cars status
                    using (MySqlConnection connUpdate = new MySqlConnection(connectionStr))
                    {
                        connUpdate.Open();
                        string selectedCar = returnc.Text;

                        if (!string.IsNullOrEmpty(selectedCar))
                        {
                            string updateCarStatusQuery = "UPDATE tbl_cars SET STATUS = 'AVAILABLE' WHERE REGNO = @selectedCar AND STATUS = 'BOOKED'";
                            using (MySqlCommand updateCarStatusCmd = new MySqlCommand(updateCarStatusQuery, connUpdate))
                            {
                                updateCarStatusCmd.Parameters.AddWithValue("@selectedCar", selectedCar);

                                int rowsAffected = updateCarStatusCmd.ExecuteNonQuery();

                                if (rowsAffected == 0)
                                {
                                    MessageBox.Show("No car found with the selected criteria or car is not booked.");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select a car.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            btnreturn.Cursor = Cursors.Hand;
        }

        private void DisplayData()
        {
            string connection = "server=localhost;user id=root;password=;database=carrental";
            string query = "SELECT * FROM tbl_return";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void uc4_Load(object sender, EventArgs e)
        {
            DisplayData();
           RefreshData();
            
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

                returnc.Items.Add(combinedText);



            }
            conn.Close();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
           DisplayData ();
        }

        private void txtcustomerid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
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


                    textBox1.Text = combinedText;
                }
                else
                {
                    MessageBox.Show("Customer ID Not Found");
                }
                conn.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnreturn_MouseHover(object sender, EventArgs e)
        {
            btnreturn.Cursor = Cursors.Hand;
        }

        private void gunaGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void returnc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
