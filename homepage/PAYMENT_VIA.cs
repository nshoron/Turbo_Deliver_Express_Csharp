using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace homepage
{
    public partial class PAYMENT_VIA : Form
    {
        public PAYMENT_VIA()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "SELECT * FROM PAYMENT WHERE Name_On_Card=@name_on_card and Card_Number=@card_number and Valid_On=@valid_on and CVV_No=@cvv_no";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name_on_card", textBox1.Text);
                cmd.Parameters.AddWithValue("@card_number", textBox2.Text);
                cmd.Parameters.AddWithValue("@valid_on", textBox3.Text);
                cmd.Parameters.AddWithValue("@cvv_no", textBox4.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    MessageBox.Show("Payment Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();


                }
                else
                {
                    MessageBox.Show("Payment Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Enter Fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
