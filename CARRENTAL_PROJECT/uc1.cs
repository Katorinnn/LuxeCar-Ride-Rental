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
    public partial class uc1 : UserControl
    {
        MySqlDataAdapter adapt;
        private Timer refreshTimer;
        public uc1()
        {
            InitializeComponent();
            refreshTimer = new Timer();
            refreshTimer.Interval = 5000; // Set the interval in milliseconds (e.g., 5000ms = 5 seconds)
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
           
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            {
                string connection = "server=localhost;user id=root;password=;database=carrental";

                // Check if any of the input fields is empty
                if (string.IsNullOrWhiteSpace(this.cname.Text) || string.IsNullOrWhiteSpace(this.address.Text) || string.IsNullOrWhiteSpace(this.contact.Text) || string.IsNullOrWhiteSpace(this.validid.Text))
                {
                    MessageBox.Show("Please fill in all the fields before saving.");
                }
                else
                {
                    string query = "INSERT INTO tbl_customer(CUSTOMERNAME,ADDRESS,CONTACT,VALIDID) VALUES('" + this.cname.Text + "','" + this.address.Text + "','" + this.contact.Text + "','" + this.validid.Text + "')";
                    MySqlConnection conn = new MySqlConnection(connection);
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader dr;

                    conn.Open();
                    dr = cmd.ExecuteReader();
                    MessageBox.Show("Successfully Saved");
                    conn.Close();
                }

                btnadd.Cursor = Cursors.Hand;
            }



        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost;user id=root;password=;database=carrental";
            string query = "UPDATE tbl_customer SET CUSTOMERNAME='" + this.cname.Text + "',ADDRESS='" + this.address.Text + "',CONTACT='" + this.contact.Text + "',VALIDID='" + this.validid.Text + "'WHERE CUSTOMERID='" + this.customerid.Text + "'";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Record has been Updated Successfully");
            conn.Close();

            btnedit.Cursor = Cursors.Hand;
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            customerid.Text = string.Empty;
            cname.Text = string.Empty;
            address.Text = string.Empty;
            contact.Text = string.Empty;
            validid.Text = string.Empty;

            btnreset.Cursor = Cursors.Hand;


        }

        private void uc1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void RefreshData()
        {
            string connection = "server=localhost;user id=root;password=;database=carrental";
            string query = "SELECT * FROM tbl_customer";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                customerid.Text = row.Cells[0].Value.ToString();
                cname.Text = row.Cells[1].Value.ToString();
                address.Text = row.Cells[2].Value.ToString();
                contact.Text = row.Cells[3].Value.ToString();
                validid.Text = row.Cells[4].Value.ToString();


            }
        }

        private void customerid_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnload_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost;user id=root;password=;database=carrental";
            string query = "SELECT * FROM tbl_customer";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            btnload.Cursor = Cursors.Hand;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void gunaGradientPanel1_Click(object sender, EventArgs e)
        {
            gunaGradientPanel1.Visible = true;
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost;user id=root;password=;database=carrental";
            string query = "INSERT INTO tbl_customer(CUSTOMERNAME,ADDRESS,CONTACT,VALIDID)VALUES('" + this.cname.Text + "','" + this.address.Text + "','" + this.contact.Text + "','" + this.validid.Text + "')";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Successfully Saved");
            conn.Close();
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost;user id=root;password=;database=carrental";
            string query = "UPDATE tbl_customer SET CUSTOMERNAME='" + this.cname.Text + "',ADDRESS='" + this.address.Text + "',CONTACT='" + this.contact.Text + "',VALIDID='" + this.validid.Text + "'WHERE CUSTOMERID='" + this.customerid.Text + "'";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Record has been Updated Successfully");
            conn.Close();
        }

        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost;user id=root;password=;database=carrental";
            string query = "SELECT * FROM tbl_customer";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void gunaGradientButton4_Click(object sender, EventArgs e)
        {
            customerid.Text = string.Empty;
            cname.Text = string.Empty;
            address.Text = string.Empty;
            contact.Text = string.Empty;
            validid.Text = string.Empty;
        }

        private void contact_TextChanged(object sender, EventArgs e)
        {

        }

        private void validid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void address_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
