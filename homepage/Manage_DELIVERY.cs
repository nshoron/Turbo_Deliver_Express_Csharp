using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace homepage
{
    public partial class Manage_DELIVERY : Form
    {
        public Manage_DELIVERY()
        {
            InitializeComponent();
            LoadDataIntoDataGridView();
        }
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        private void LoadDataIntoDataGridView()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT username,fullname,gender,email,mobileNumber,picture FROM REGISTRATION where ROLE='RIDER'"; // Replace YourTableName with your actual table name
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label6.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            label8.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            label12.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            label11.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            label15.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[5].Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from REGISTRATION where username=@username";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", label6.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("DELIVERYMAN REMOVED");

            }
            else
            {
                MessageBox.Show("DELIVERYMAN NOT REMOVED");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentRowIndex < dataGridView1.Rows.Count - 1)
                {
                    currentRowIndex++;
                    DisplayInformationFromCurrentRow();
                }
                else
                {
                    MessageBox.Show("No Information Avialable", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        public int currentRowIndex = 0;
        private void DisplayInformationFromCurrentRow()
        {
            try
            {
                if (dataGridView1.Rows.Count > 0 && dataGridView1.Rows[currentRowIndex].Cells.Count >= 6)
                {



                    label6.Text = dataGridView1.Rows[currentRowIndex].Cells[0].Value?.ToString() ?? "";
                    label8.Text = dataGridView1.Rows[currentRowIndex].Cells[1].Value?.ToString() ?? "";
                    label12.Text = dataGridView1.Rows[currentRowIndex].Cells[2].Value?.ToString() ?? "";
                    label11.Text = dataGridView1.Rows[currentRowIndex].Cells[3].Value?.ToString() ?? "";
                    label15.Text = dataGridView1.Rows[currentRowIndex].Cells[4].Value?.ToString() ?? "";
                    pictureBox1.Image = GetPhoto((byte[])dataGridView1.Rows[currentRowIndex].Cells[5].Value);

                }
                else
                {
                    MessageBox.Show("No Information Avialable.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (currentRowIndex < dataGridView1.Rows.Count - 1)
                {
                    currentRowIndex--;
                    DisplayInformationFromCurrentRow();
                }
                else
                {
                    MessageBox.Show("No Information Avialable", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private void Manage_DELIVERY_Load(object sender, EventArgs e)
        {
            DisplayInformationFromCurrentRow();
        }
    }
}
