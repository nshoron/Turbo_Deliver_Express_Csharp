using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace homepage
{
    public partial class Available_parcels : Form
    {
        public Available_parcels()
        {
            InitializeComponent();
            LoadDataIntoDataGridView();


        }
        public Available_parcels(String D_username)
        {
            InitializeComponent();
            LoadDataIntoDataGridView();
            label19.Text = D_username;


        }
        private void LoadDataIntoDataGridView()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Parcel_Id,from_area,Pickup_point,to_area,r_address,r_name,r_mobile_no ,charge FROM PARCEL_DETAILS WHERE status='Pending'";
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



        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public int currentRowIndex = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "UPDATE PARCEL_DETAILS set D_username=@d_username,status='Confirmed',D_payment=@d_payment where parcel_id=@parcel_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@d_username", label19.Text);
            cmd.Parameters.AddWithValue("@parcel_id", label17.Text);
            double Payment = double.Parse(label5.Text) * 0.25;
            cmd.Parameters.AddWithValue("@d_payment", Payment.ToString());

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                DialogResult dialogResult = MessageBox.Show("You will get:" + Payment);

                LoadDataIntoDataGridView();


            }
            else
            {
                MessageBox.Show("Parcel is not available");
            }

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void Available_parcels_Load(object sender, EventArgs e)
        {
            DisplayInformationFromCurrentRow();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label17.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            label6.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            label11.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            label8.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            label13.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            label7.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            label9.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            label5.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();


        }
        private void DisplayInformationFromCurrentRow()
        {
            try
            {
                if (dataGridView1.Rows.Count > 0 && dataGridView1.Rows[currentRowIndex].Cells.Count >= 8)
                {
                    label17.Text = dataGridView1.Rows[currentRowIndex].Cells[0].Value?.ToString() ?? "";
                    label6.Text = dataGridView1.Rows[currentRowIndex].Cells[1].Value?.ToString() ?? "";
                    label11.Text = dataGridView1.Rows[currentRowIndex].Cells[2].Value?.ToString() ?? "";
                    label8.Text = dataGridView1.Rows[currentRowIndex].Cells[3].Value?.ToString() ?? "";
                    label13.Text = dataGridView1.Rows[currentRowIndex].Cells[4].Value?.ToString() ?? "";
                    label7.Text = dataGridView1.Rows[currentRowIndex].Cells[5].Value?.ToString() ?? "";
                    label9.Text = dataGridView1.Rows[currentRowIndex].Cells[6].Value?.ToString() ?? "";
                    label5.Text = dataGridView1.Rows[currentRowIndex].Cells[7].Value?.ToString() ?? "";
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

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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
    }
}
