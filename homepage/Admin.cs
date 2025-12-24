using System;
using System.Windows.Forms;

namespace homepage
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        public Admin(String user)
        {
            InitializeComponent();

            label1.Text = user;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Profile P2 = new Admin_Profile(label1.Text);
            P2.TopLevel = false;
            panel1.Controls.Add(P2);
            P2.BringToFront();
            P2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Manage_Customer P2 = new Manage_Customer();
            P2.TopLevel = false;
            panel1.Controls.Add(P2);
            P2.BringToFront();
            P2.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Manage_DELIVERY P2 = new Manage_DELIVERY();
            P2.TopLevel = false;
            panel1.Controls.Add(P2);
            P2.BringToFront();
            P2.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage h1 = new Homepage();
            h1.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ADMIN_DASHBOARD P2 = new ADMIN_DASHBOARD();
            P2.TopLevel = false;
            panel1.Controls.Add(P2);
            P2.BringToFront();
            P2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            ADD_ADMIN P2 = new ADD_ADMIN();
            P2.TopLevel = false;
            panel1.Controls.Add(P2);
            P2.BringToFront();
            P2.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            ADMIN_DASHBOARD P2 = new ADMIN_DASHBOARD();
            P2.TopLevel = false;
            panel1.Controls.Add(P2);
            P2.BringToFront();
            P2.Show();

        }
    }
}
