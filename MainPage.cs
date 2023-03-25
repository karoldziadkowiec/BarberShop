using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarberShop
{
    public partial class MainPage : Form
    {
        User userr = null;
        public MainPage(User user)
        {
            InitializeComponent();
            button9.Text = "Profil: " + user.login;
            userr = user;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginPage loginpage = new LoginPage();
            loginpage.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            EditProfilePage editprofilepage = new EditProfilePage(userr);
            editprofilepage.Show();
            this.Hide();
        }
        
        public void button9_Click(object sender, EventArgs e)
        {
            MyProfilePage myprofilepage = new MyProfilePage(userr);
            myprofilepage.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            CreateVisitPage createvisitpage = new CreateVisitPage(userr);
            createvisitpage.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateVisitPage createvisitpage = new CreateVisitPage(userr);
            createvisitpage.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyVisitsPage myvisitspage = new MyVisitsPage(userr);
            myvisitspage.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ServicesPage servicespage = new ServicesPage(userr);
            servicespage.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TeamPage teampage = new TeamPage(userr);
            teampage.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ContactPage contactpage = new ContactPage(userr);
            contactpage.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
