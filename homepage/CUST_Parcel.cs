using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace homepage
{
    public partial class CUST_Parcel : Form
    {
        public CUST_Parcel()
        {
            InitializeComponent();

        }
        public CUST_Parcel(String user)
        {
            InitializeComponent();
            label14.Text = user;

        }


        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;



        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox3.SelectedItem != null && comboBox4.SelectedItem != null
                && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {

                SqlConnection con = new SqlConnection(cs);
                string query = "insert into PARCEL_DETAILS values (@username,@from_area,@to_area,@parcel_type,@quantity,@weight,@charge,@r_name,@r_mobile_no,@r_address,@status,@D_username,@Pickup_point,@D_payment)";

                double charge = double.Parse(comboBox4.SelectedItem.ToString()) * double.Parse(textBox1.Text.ToString()) * 20;





                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@username", label14.Text);
                cmd.Parameters.AddWithValue("@from_area", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@to_area", comboBox2.SelectedItem);
                cmd.Parameters.AddWithValue("@parcel_type", comboBox3.SelectedItem);
                cmd.Parameters.AddWithValue("@quantity", comboBox4.SelectedItem);
                cmd.Parameters.AddWithValue("@weight", textBox1.Text);
                cmd.Parameters.AddWithValue("@charge", charge);
                cmd.Parameters.AddWithValue("@r_name", textBox2.Text);
                cmd.Parameters.AddWithValue("@r_mobile_no", textBox3.Text);
                cmd.Parameters.AddWithValue("@r_address", textBox4.Text);
                cmd.Parameters.AddWithValue("@status", label15.Text);
                cmd.Parameters.AddWithValue("@D_username", label17.Text);
                cmd.Parameters.AddWithValue("@Pickup_point", textBox5.Text);
                cmd.Parameters.AddWithValue("@D_payment", label17.Text);



                con.Open();

                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("You have to pay:" + charge);
                    Reset();


                    PAYMENT_VIA P2 = new PAYMENT_VIA();

                    P2.Show();




                }
                else
                {
                    MessageBox.Show("Booking Failed");
                }


                con.Close();
            }



            else
            {
                MessageBox.Show("Enter Fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void CUST_Parcel_Load(object sender, EventArgs e)
        {

        }
        private void Reset()
        {
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            comboBox4.SelectedItem = null;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}



