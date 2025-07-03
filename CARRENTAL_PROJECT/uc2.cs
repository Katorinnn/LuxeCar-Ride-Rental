using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;
namespace CARRENTAL_PROJECT
{
    public partial class uc2 : UserControl
    {
        MySqlDataAdapter adapt;
        private Timer refreshTimer;
        public uc2()
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
                if (string.IsNullOrWhiteSpace(this.carreg.Text) || string.IsNullOrWhiteSpace(this.brand.Text) || string.IsNullOrWhiteSpace(this.model.Text) || string.IsNullOrWhiteSpace(this.status.Text) || string.IsNullOrWhiteSpace(this.price.Text) || string.IsNullOrWhiteSpace(pictureBox2.ImageLocation))
                {
                    MessageBox.Show("Please fill in all the fields before saving.");
                }
                else
                {
                    string query = "INSERT INTO tbl_cars(CARREG,BRAND,MODEL,STATUS,PRICE,IMAGE) VALUES('" + this.carreg.Text + "','" + this.brand.Text + "','" + this.model.Text + "','" + this.status.Text + "', '" + this.price.Text + "', '" + Path.GetFileName(pictureBox2.ImageLocation) + "')";
                    MySqlConnection conn = new MySqlConnection(connection);
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader dr;

                    conn.Open();
                    dr = cmd.ExecuteReader();
                    MessageBox.Show("Successfully Saved");
                    conn.Close();

                    // Copy image file to destination
                    File.Copy(imageText.Text, Application.StartupPath + @"\Image\" + Path.GetFileName(pictureBox2.ImageLocation));

                    // Refresh the displayed data
                    DisplayData();
                }
            }
            


        }

        private void DisplayData()
        {
            string connection = "server = localhost; user id = root; password=;database =carrental";
            DataTable dt = new DataTable();
            adapt = new MySqlDataAdapter("SELECT * FROM carrental.tbl_cars", connection);
            adapt.Fill(dt);
            dt.Columns.Add("PICTURE", Type.GetType("System.Byte[]"));

            foreach (DataRow row in dt.Rows)
            {
                row["PICTURE"] = File.ReadAllBytes(Application.StartupPath + @"\Image\" + Path.GetFileName(row["IMAGE"].ToString()));
            }
            dataGridView1.DataSource = dt;

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost;user id=root;password=;database=carrental";
            string query = "UPDATE tbl_cars SET CARREG='" + this.carreg.Text + "',BRAND='" + this.brand.Text + "',MODEL='" + this.model.Text + "',STATUS='" + this.status.Text + "',PRICE='" + this.price.Text + "'WHERE REGNO='" + this.regno.Text + "'";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Record has been Updated Successfully");
            conn.Close();
            DisplayData();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            regno.Text = string.Empty;
            carreg.Text = string.Empty;
            brand.Text = string.Empty;
            model.Text = string.Empty;
            status.Text = string.Empty;
            price.Text = string.Empty;
        }

        private void uc2_Load(object sender, EventArgs e)
        {
           
        }

        private void RefreshData()
        {
            string connection = "server=localhost;user id=root;password=;database=carrental";
            string query = "SELECT * FROM tbl_cars";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Add("PICTURE", Type.GetType("System.Byte[]"));

            foreach (DataRow row in dt.Rows)
            {
                row["PICTURE"] = File.ReadAllBytes(Application.StartupPath + @"\Image\" + Path.GetFileName(row["IMAGE"].ToString()));
            }
            dataGridView1.DataSource = dt;
            DisplayData();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog();
            openfd.Filter = "pics Files(*.jpg;*.jpeg;*.gif;) | *.jpg;*.jpeg;*.gif;";
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                imageText.Text = openfd.FileName;
                pictureBox2.Image = new Bitmap(openfd.FileName);
                pictureBox2.ImageLocation = openfd.FileName;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                regno.Text = row.Cells[0].Value.ToString();
                carreg.Text = row.Cells[1].Value.ToString();
                brand.Text = row.Cells[2].Value.ToString();
                model.Text = row.Cells[3].Value.ToString();
                status.Text = row.Cells[4].Value.ToString();
                price.Text = row.Cells[5].Value.ToString();
                byte[] imgData = (byte[])dataGridView1.CurrentRow.Cells[7].Value;
                MemoryStream ms = new MemoryStream(imgData);
                pictureBox2.Image = Image.FromStream(ms);

                dataGridView1.Cursor = Cursors.Hand;
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost;user id=root;password=;database=carrental";
            string query = "SELECT * FROM tbl_cars";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Add("PICTURE", Type.GetType("System.Byte[]"));

            foreach (DataRow row in dt.Rows)
            {
                row["PICTURE"] = File.ReadAllBytes(Application.StartupPath + @"\Image\" + Path.GetFileName(row["IMAGE"].ToString()));
            }
            dataGridView1.DataSource = dt;
            
        }

        private void regno_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string connection = "server=localhost;user id=root;password=;database=carrental";

            // Check if any of the input fields is empty
            if (string.IsNullOrWhiteSpace(this.carreg.Text) || string.IsNullOrWhiteSpace(this.brand.Text) || string.IsNullOrWhiteSpace(this.model.Text) || string.IsNullOrWhiteSpace(this.status.Text) || string.IsNullOrWhiteSpace(this.price.Text) || string.IsNullOrWhiteSpace(pictureBox2.ImageLocation))
            {
                MessageBox.Show("Please fill in all the fields before saving.");
            }
            else
            {
                string query = "INSERT INTO tbl_cars(CARREG,BRAND,MODEL,STATUS,PRICE,IMAGE) VALUES('" + this.carreg.Text + "','" + this.brand.Text + "','" + this.model.Text + "','" + this.status.Text + "', '" + this.price.Text + "', '" + Path.GetFileName(pictureBox2.ImageLocation) + "')";
                MySqlConnection conn = new MySqlConnection(connection);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dr;

                conn.Open();
                dr = cmd.ExecuteReader();
                MessageBox.Show("Successfully Saved");
                conn.Close();

                // Copy image file to destination
                File.Copy(imageText.Text, Application.StartupPath + @"\Image\" + Path.GetFileName(pictureBox2.ImageLocation));

                // Refresh the displayed data
                DisplayData();
            }




        }
    }
}
