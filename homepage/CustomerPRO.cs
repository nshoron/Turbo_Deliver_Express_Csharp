using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;



namespace homepage
{
    public partial class CustomerPRO : Form
    {
        public CustomerPRO()
        {
            InitializeComponent();
        }
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public CustomerPRO(String user)
        {
            InitializeComponent();
            label3.Text = user;
            string username = label3.Text;
            string query = "SELECT C_ID ,FullName ,Gender , DateOfBirth ,Email ,MobileNumber , Username ,password  ,ROLE, Picture from REGISTRATION where username=@username";

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            label1.Text = reader["Fullname"].ToString();


                            label4.Text = reader["Email"].ToString();
                            label5.Text = reader["MOBILENUMBER"].ToString();


                            label12.Text = reader["PASSWORD"].ToString();
                            pictureBox1.Image = GetPhoto((byte[])reader["PICTURE"]);
                        }
                        else
                        {
                            MessageBox.Show("User not found.");
                        }
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CustomerPRO_Load(object sender, EventArgs e)
        {

        }
    }

}



