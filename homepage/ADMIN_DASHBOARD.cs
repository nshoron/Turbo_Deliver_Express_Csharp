using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace homepage
{
    public partial class ADMIN_DASHBOARD : Form
    {
        public ADMIN_DASHBOARD()
        {
            InitializeComponent();
        }

        private void ADMIN_DASHBOARD_Load(object sender, EventArgs e)
        {
            LoadCustomerRiderCount();
            LoadParcelStatusCount();
        }
        private void LoadCustomerRiderCount()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            string query = "SELECT " +
                           "(SELECT COUNT(*) FROM REGISTRATION WHERE ROLE = 'CUSTOMER') AS CustomerCount, " +
                           "(SELECT COUNT(*) FROM REGISTRATION WHERE ROLE = 'RIDER') AS RiderCount";

            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int customerCount = Convert.ToInt32(reader["CustomerCount"]);
                                int riderCount = Convert.ToInt32(reader["RiderCount"]);

                                label1.Text = customerCount.ToString();
                                label2.Text = riderCount.ToString();
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
        private void LoadParcelStatusCount()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            string query = "SELECT " +
                           "(SELECT COUNT(*) FROM PARCEL_DETAILS WHERE Status = 'Confirmed') AS ConfirmedCount, " +
                            "(SELECT COUNT(*) FROM PARCEL_DETAILS WHERE Status = 'PICKED UP') AS PICKEDUPCount, " +

                           "(SELECT COUNT(*) FROM PARCEL_DETAILS WHERE Status = 'DELIVERIED') AS DeliveredCount";

            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int ConfirmedCount = Convert.ToInt32(reader["ConfirmedCount"]);
                                int deliveredCount = Convert.ToInt32(reader["DeliveredCount"]);
                                int PICKEDUPCount = Convert.ToInt32(reader["PICKEDUPCount"]);

                                label5.Text = ConfirmedCount.ToString();
                                label6.Text = deliveredCount.ToString();
                                label11.Text = PICKEDUPCount.ToString();
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


    }
}
