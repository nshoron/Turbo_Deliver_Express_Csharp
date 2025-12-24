using System;
using System.Windows.Forms;


namespace homepage
{
    public partial class DMSIGN : Form
    {
        public DMSIGN()
        {
            InitializeComponent();
        }
        public DMSIGN(String user)
        {
            InitializeComponent();

            label1.Text = user;

        }


        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage f2 = new Homepage();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DELI_PROFILE p2 = new DELI_PROFILE(label1.Text);
            p2.TopLevel = false;
            panel1.Controls.Add(p2);
            p2.BringToFront();
            p2.Show();
            p2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Available_parcels p2 = new Available_parcels(label1.Text);
            p2.TopLevel = false;
            panel1.Controls.Add(p2);
            p2.BringToFront();
            p2.Show();
            p2.Show();

        }

        private void DMSIGN_Load(object sender, EventArgs e)
        {
            DM_DASHBOARD p2 = new DM_DASHBOARD(label1.Text);
            p2.TopLevel = false;
            panel1.Controls.Add(p2);
            p2.BringToFront();
            p2.Show();
            p2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage p1 = new Homepage();
            p1.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Update_Parcels p2 = new Update_Parcels(label1.Text);
            p2.TopLevel = false;
            panel1.Controls.Add(p2);
            p2.BringToFront();
            p2.Show();
            p2.Show();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            DM_DASHBOARD p2 = new DM_DASHBOARD(label1.Text);
            p2.TopLevel = false;
            panel1.Controls.Add(p2);
            p2.BringToFront();
            p2.Show();
            p2.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
