using MySql.Data.MySqlClient;
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
    public partial class uc5 : UserControl
    {
        private DateTime startTime;  // Declare startTime as a class variable
        private Timer timer;

        MySqlDataAdapter adapt;
        private Timer refreshTimer;
        public uc5()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            startTime = DateTime.Now;
            InitializeTimer();
            refreshTimer = new Timer();
            refreshTimer.Interval = 10000; // Set the interval in milliseconds (e.g., 5000ms = 5 seconds)
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();

        }

        private void uc5_Load(object sender, EventArgs e)
        {
            string connection = "server=localhost;user id=root;password=;database=carrental";
            string query = "SELECT COUNT(*) FROM tbl_cars WHERE STATUS = 'AVAILABLE'";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            conn.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            CARS.Text = dt.Rows[0][0].ToString();
            conn.Close();

            string connection1 = "server=localhost;user id=root;password=;database=carrental";
            string query1 = "SELECT COUNT(*) FROM tbl_customer";
            MySqlConnection conn1 = new MySqlConnection(connection1);
            MySqlDataAdapter da1 = new MySqlDataAdapter(query1, conn1);
            conn1.Open();
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            CUST.Text = dt1.Rows[0][0].ToString();
            conn1.Close();

            string connection2 = "server=localhost;user id=root;password=;database=carrental";
            string query2 = "SELECT COUNT(*) FROM tbl_rental";
            MySqlConnection conn2 = new MySqlConnection(connection2);
            MySqlDataAdapter da2 = new MySqlDataAdapter(query2, conn2);
            conn2.Open();

            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            RENT.Text = dt2.Rows[0][0].ToString();
            conn2.Close();

            string connection3 = "server=localhost;user id=root;password=;database=carrental";
            string query3 = "SELECT COUNT(*) FROM tbl_cars WHERE STATUS = 'BOOKED'";
            MySqlConnection conn3 = new MySqlConnection(connection3);
            MySqlDataAdapter da3 = new MySqlDataAdapter(query3, conn3);
            conn3.Open();

            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            label2.Text = dt3.Rows[0][0].ToString();
            conn3.Close();

            string connection4 = "server=localhost;user id=root;password=;database=carrental";
            string query4 = "SELECT COUNT(*) FROM tbl_return";
            MySqlConnection conn4 = new MySqlConnection(connection4);
            MySqlDataAdapter da4 = new MySqlDataAdapter(query4, conn4);
            conn4.Open();
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            label3.Text = dt4.Rows[0][0].ToString();

            conn4.Close();
        }

        private void RefreshData()
        {
            string connection = "server=localhost;user id=root;password=;database=carrental";
            string query = "SELECT COUNT(*) FROM tbl_cars WHERE STATUS = 'AVAILABLE'";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            conn.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            CARS.Text = dt.Rows[0][0].ToString();
            conn.Close();

            string connection1 = "server=localhost;user id=root;password=;database=carrental";
            string query1 = "SELECT COUNT(*) FROM tbl_customer";
            MySqlConnection conn1 = new MySqlConnection(connection1);
            MySqlDataAdapter da1 = new MySqlDataAdapter(query1, conn1);
            conn1.Open();
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            CUST.Text = dt1.Rows[0][0].ToString();
            conn1.Close();

            string connection2 = "server=localhost;user id=root;password=;database=carrental";
            string query2 = "SELECT COUNT(*) FROM tbl_rental";
            MySqlConnection conn2 = new MySqlConnection(connection2);
            MySqlDataAdapter da2 = new MySqlDataAdapter(query2, conn2);
            conn2.Open();

            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            RENT.Text = dt2.Rows[0][0].ToString();
            conn2.Close();

            string connection3 = "server=localhost;user id=root;password=;database=carrental";
            string query3 = "SELECT COUNT(*) FROM tbl_cars WHERE STATUS = 'BOOKED'";
            MySqlConnection conn3 = new MySqlConnection(connection3);
            MySqlDataAdapter da3 = new MySqlDataAdapter(query3, conn3);
            conn3.Open();

            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            label2.Text = dt3.Rows[0][0].ToString();
            conn3.Close();

            string connection4 = "server=localhost;user id=root;password=;database=carrental";
            string query4 = "SELECT COUNT(*) FROM tbl_return";
            MySqlConnection conn4 = new MySqlConnection(connection4);
            MySqlDataAdapter da4 = new MySqlDataAdapter(query4, conn4);
            conn4.Open();
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            label3.Text = dt4.Rows[0][0].ToString();

            conn4.Close();
        }
            private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RENT_Click(object sender, EventArgs e)
        {

        }

        private void InitializeTimer()
        {
            // Initialize the timer
            timer = new Timer();
            timer.Interval = 1000; // Set the interval to 1000 milliseconds (1 second)
            timer.Tick += Timer_Tick;

            // Start the timer
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Check if 24 hours have passed since the startTime
            if ((DateTime.Now - startTime).TotalHours >= 24)
            {
                // Update your label to "00" or perform any other action
                // For example, if you have a label named 'label1', you can do:
                RENT.Text = "00";
                label3.Text = "00";

                // Reset the startTime
                startTime = DateTime.Now;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

}
