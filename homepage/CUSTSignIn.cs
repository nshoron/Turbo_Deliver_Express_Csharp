using System;
using System.Windows.Forms;

namespace homepage
{
    public partial class CUSTSignIn : Form
    {


        public CUSTSignIn()
        {
            InitializeComponent();

        }

        public CUSTSignIn(String user)
        {
            InitializeComponent();

            custLabel.Text = user;

        }


        public void addUserControl(UserControl userControl)
        {


        }


        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage f2 = new Homepage();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            CustomerPRO p2 = new CustomerPRO(custLabel.Text);
            p2.TopLevel = false;
            panel1.Controls.Add(p2);
            p2.BringToFront();
            p2.Show();
            p2.Show();


        }

        private void custLabel_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {



            CUST_Parcel P2 = new CUST_Parcel(custLabel.Text);
            P2.TopLevel = false;
            panel1.Controls.Add(P2);
            P2.BringToFront();
            P2.Show();




        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage f2 = new Homepage();
            f2.Show();

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            TRACK_PARCEL P2 = new TRACK_PARCEL(custLabel.Text);
            P2.TopLevel = false;
            panel1.Controls.Add(P2);
            P2.BringToFront();
            P2.Show();


        }

        private void CUSTSignIn_Load(object sender, EventArgs e)
        {

            CUST_Parcel P2 = new CUST_Parcel(custLabel.Text);
            P2.TopLevel = false;
            panel1.Controls.Add(P2);
            P2.BringToFront();
            P2.Show();
        }
    }
}


