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
    public partial class AdminMyProfile : Form
    {
        User userr = null;
        public AdminMyProfile(User user)
        {
            InitializeComponent();
            imie.Text = user.name;
            email.Text = user.email;
            login.Text = user.login;
            numer.Text = user.phone;
            data.Text = user.date;
            adres.Text = user.address;
            button9.Text = user.name;
            userr = user;
        }

        private void AdminMyProfile_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminContactPage admincontactpage = new AdminContactPage(userr);
            admincontactpage.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdminTeamPage adminteampage = new AdminTeamPage(userr);
            adminteampage.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdminServicesPage adminservicespage = new AdminServicesPage(userr);
            adminservicespage.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AdminMainPage adminmainpage = new AdminMainPage(userr);
            adminmainpage.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminCreateVisitPage admincreatevisitpage = new AdminCreateVisitPage(userr);
            admincreatevisitpage.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminVisitsPage adminvisitspage = new AdminVisitsPage(userr);
            adminvisitspage.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AdminClientsPage adminclientspage = new AdminClientsPage(userr);
            adminclientspage.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AdminStorePage adminstorepage = new AdminStorePage(userr);
            adminstorepage.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminEditProfilePage admineditprofilepage = new AdminEditProfilePage(userr);
            admineditprofilepage.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginPage loginpage = new LoginPage();
            loginpage.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AdminEditProfilePage admineditprofilepage = new AdminEditProfilePage(userr);
            admineditprofilepage.Show();
            this.Hide();
        }
    }
}
