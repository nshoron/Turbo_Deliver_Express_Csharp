using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace homepage
{
    public partial class ADD_ADMIN : Form
    {
        public ADD_ADMIN()
        {
            InitializeComponent();
        }
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && (radioButton1.Checked || radioButton2.Checked) && dateTimePicker2.Checked)
            {

                if (IsUsernameUnique(textBox5.Text))
                {
                    SqlConnection con = new SqlConnection(cs);
                    string query = "insert into REGISTRATION values (@fullname,@gender,@dob,@email,@mobile_no,@username,@password,@Role,@picture)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@fullname", textBox1.Text);

                    if (radioButton1.Checked)
                    {
                        cmd.Parameters.AddWithValue("@gender", "Male");
                    }
                    else if (radioButton2.Checked)
                    {
                        cmd.Parameters.AddWithValue("@gender", "Female");
                    }

                    DateTime selectedDate = dateTimePicker2.Value;
                    cmd.Parameters.AddWithValue("@dob", selectedDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@email", textBox3.Text);
                    cmd.Parameters.AddWithValue("@mobile_no", textBox4.Text);
                    cmd.Parameters.AddWithValue("@username", textBox5.Text);
                    cmd.Parameters.AddWithValue("@password", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Role", "ADMIN");




                    cmd.Parameters.AddWithValue("@picture", SavePhoto());

                    con.Open();

                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Admin Added Successfully");
                        Reset();


                    }
                    else
                    {
                        MessageBox.Show("Adding Failed");
                    }

                    con.Close();
                }
                else
                {
                    MessageBox.Show("Username is already taken. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter Fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool IsUsernameUnique(string username)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM REGISTRATION WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);


                int count = (int)command.ExecuteScalar();

                return count == 0;
            }
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }
        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            //ofd.Filter = "PNG FILE (*.PNG) | *.PNG";
            ofd.Filter = "ALL IMAGE FILE (*.*) | *.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ADD_ADMIN_Load(object sender, EventArgs e)
        {

        }
        public void Reset()
        {
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            dateTimePicker2.Checked = false;
            pictureBox1.Image = Properties.Resources.no_image_avaiable;
        }
    }
}
