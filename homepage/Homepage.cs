using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace homepage
{
    public partial class Homepage : Form
    {




        public Homepage()
        {
            InitializeComponent();


        }

        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;





        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void button1_Click(object sender, EventArgs e)
        {


            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string queryCustomer = "select * from REGISTRATION where username=@user and password = @pass";


                SqlCommand cmdCustomer = new SqlCommand(queryCustomer, con);




                cmdCustomer.Parameters.AddWithValue("@user", textBox1.Text);
                cmdCustomer.Parameters.AddWithValue("@pass", textBox2.Text);






                con.Open();

                SqlDataReader drCustomer = cmdCustomer.ExecuteReader();

                if (drCustomer.HasRows)
                {
                    while (drCustomer.Read())
                    {
                        string role = drCustomer["ROLE"].ToString();

                        if (role == "CUSTOMER")
                        {
                            MessageBox.Show("Customer Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            CUSTSignIn f2 = new CUSTSignIn(textBox1.Text);


                            f2.Show();

                        }
                        else if (role == "RIDER")
                        {
                            MessageBox.Show("DeliveryMan Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            DMSIGN f2 = new DMSIGN(textBox1.Text);
                            f2.Show();
                        }
                        else if (role == "ADMIN")
                        {
                            MessageBox.Show("Admin Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            Admin f2 = new Admin(textBox1.Text);
                            f2.Show();
                        }
                    }








                }
                else { MessageBox.Show("LOGIN FAILED", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); }




                con.Close();

            }




            else
            {
                MessageBox.Show("Enter Fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }



        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUpPage f2 = new SignUpPage();
            f2.Show();
        }
        void ResetControl()
        {
            textBox1.Clear();
            textBox2.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            button5.BringToFront();
            textBox2.UseSystemPasswordChar = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            button4.BringToFront();
            textBox2.UseSystemPasswordChar = true;
        }

        private void Homepage_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();

                errorProvider1.SetError(this.textBox1, "Enter Username");
            }
            else
            {

                errorProvider1.SetError(this.textBox1, "");
            }

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();

                errorProvider1.SetError(this.textBox2, "Enter Fullname");
            }
            else
            {

                errorProvider1.SetError(this.textBox2, "");
            }

        }
    }
}