using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace homepage
{
    public partial class TRACK_PARCEL : Form
    {
        public TRACK_PARCEL()
        {
            InitializeComponent();
        }
        public TRACK_PARCEL(string USER)
        {
            InitializeComponent();
            label9.Text = USER;
            LoadDataIntoDataGridView();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public int currentRowIndex = 0;

        private void LoadDataIntoDataGridView()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Parcel_Id,username,r_name,status,d_username FROM PARCEL_DETAILS WHERE username=@username";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@username", label9.Text);

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
        private void DisplayInformationFromCurrentRow()
        {
            try
            {
                if (dataGridView1.Rows.Count > 0 && dataGridView1.Rows[currentRowIndex].Cells.Count >= 4)
                {

                    label5.Text = dataGridView1.Rows[currentRowIndex].Cells[0].Value?.ToString() ?? "";
                    label6.Text = dataGridView1.Rows[currentRowIndex].Cells[1].Value?.ToString() ?? "";
                    label7.Text = dataGridView1.Rows[currentRowIndex].Cells[2].Value?.ToString() ?? "";
                    label8.Text = dataGridView1.Rows[currentRowIndex].Cells[3].Value?.ToString() ?? "";
                    label10.Text = dataGridView1.Rows[currentRowIndex].Cells[4].Value?.ToString() ?? "";

                }
                else
                {
                    MessageBox.Show("No data to display or not enough cells in the current row.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private void TRACK_PARCEL_Load(object sender, EventArgs e)
        {
            DisplayInformationFromCurrentRow();
        }

        private void button2_Click(object sender, EventArgs e)
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
                    MessageBox.Show("No Parcels Available", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
                    MessageBox.Show("No Parcels Available", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
