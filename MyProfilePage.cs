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
    public partial class MyProfilePage : Form
    {
        User userr = null;
        public MyProfilePage(User user)
        {
            InitializeComponent();
            imie.Text = user.name;
            nazwisko.Text = user.surname;
            email.Text = user.email;
            login.Text = user.login;
            numer.Text = user.phone;
            data.Text = user.date;
            adres.Text = user.address;
            button9.Text = "Profil: " + user.login;
            userr = user;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TeamPage teampage = new TeamPage(userr);
            teampage.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginPage loginpage = new LoginPage();
            loginpage.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ContactPage contactpage = new ContactPage(userr);
            contactpage.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ServicesPage servicespage = new ServicesPage(userr);
            servicespage.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MainPage mainpage = new MainPage(userr);
            mainpage.Show();
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

        private void button4_Click(object sender, EventArgs e)
        {
            EditProfilePage editprofilepage = new EditProfilePage(userr);
            editprofilepage.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            EditProfilePage editprofilepage = new EditProfilePage(userr);
            editprofilepage.Show();
            this.Hide();
        }

        private void MyProfilePage_Load(object sender, EventArgs e)
        {

        }

        private void imie_Click(object sender, EventArgs e)
        {

        }

        private void nazwisko_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void data_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void adres_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void numer_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void email_Click(object sender, EventArgs e)
        {

        }
    }
}
