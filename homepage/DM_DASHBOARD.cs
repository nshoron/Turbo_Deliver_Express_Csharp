using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace homepage
{
    public partial class DM_DASHBOARD : Form
    {
        public DM_DASHBOARD()
        {
            InitializeComponent();
        }
        public DM_DASHBOARD(string Duser)
        {
            InitializeComponent();
            label7.Text = Duser;
        }

        private void DM_DASHBOARD_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            string query = "SELECT " +
                           "(SELECT COUNT(*) FROM PARCEL_DETAILS WHERE Status = 'Confirmed'AND d_username = @d_username) AS ConfirmCount, " +
                           "(SELECT COUNT(*) FROM PARCEL_DETAILS WHERE Status = 'PICKED UP'AND d_username = @d_username) AS PickupCount, " +
                           "(SELECT COUNT(*) FROM PARCEL_DETAILS WHERE Status = 'DELIVERIED'AND d_username = @d_username) AS DeliveriedCount";

            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        cmd.Parameters.AddWithValue("@d_username", label7.Text);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int confirmCount = Convert.ToInt32(reader["ConfirmCount"]);
                                int pickupCount = Convert.ToInt32(reader["PickupCount"]);
                                int deliveriedCount = Convert.ToInt32(reader["DeliveriedCount"]);

                                label4.Text = confirmCount.ToString();
                                label6.Text = pickupCount.ToString();
                                label2.Text = deliveriedCount.ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string query = "SELECT SUM(D_payment) FROM PARCEL_DETAILS where d_username = @d_username";

            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@d_username", label7.Text);
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        int sum = Convert.ToInt32(result);
                        label8.Text = sum.ToString();
                    }
                    else
                    {
                        Console.WriteLine("No data in the column or column contains only NULL values.");
                    }
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
