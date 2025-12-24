using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace homepage
{
    public partial class Update_Parcels : Form
    {
        public Update_Parcels()
        {
            InitializeComponent();
        }
        public Update_Parcels(string D_username)
        {
            InitializeComponent();
            label4.Text = D_username;
            LoadDataIntoDataGridView();

        }

        private void LoadDataIntoDataGridView()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Parcel_Id,username,r_name,status FROM PARCEL_DETAILS WHERE D_username=@d_username";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@d_username", label4.Text);

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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label5.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            label7.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            label6.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            label9.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

        }
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public int currentRowIndex = 0;



        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "UPDATE PARCEL_DETAILS set status=@status where Parcel_id=@parcel_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@parcel_id", label5.Text);

            if (radioButton1.Checked)
            {
                radioButton2.Checked = false;
                cmd.Parameters.AddWithValue("@status", "PICKED UP");
            }
            if (radioButton2.Checked)
            {
                radioButton1.Checked = false;

                cmd.Parameters.AddWithValue("@status", "DELIVERIED");
            }


            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                DialogResult dialogResult = MessageBox.Show("STATUS UPDATED");

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
        private void DisplayInformationFromCurrentRow()
        {
            try
            {
                if (dataGridView1.Rows.Count > 0 && dataGridView1.Rows[currentRowIndex].Cells.Count >= 4)
                {

                    label5.Text = dataGridView1.Rows[currentRowIndex].Cells[0].Value?.ToString() ?? "";
                    label7.Text = dataGridView1.Rows[currentRowIndex].Cells[1].Value?.ToString() ?? "";
                    label6.Text = dataGridView1.Rows[currentRowIndex].Cells[2].Value?.ToString() ?? "";
                    label9.Text = dataGridView1.Rows[currentRowIndex].Cells[3].Value?.ToString() ?? "";

                }
                else
                {
                    MessageBox.Show("No Parcels Available");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private void Update_Parcels_Load(object sender, EventArgs e)
        {
            DisplayInformationFromCurrentRow();
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


    }
}
