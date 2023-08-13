using MySql.Data.MySqlClient;
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
    public partial class AdminEditProfilePage : Form
    {
        User userr = null;
        public AdminEditProfilePage(User user)
        {
            InitializeComponent();

            textBox1.Text = user.name;
            textBox2.Text = user.surname;
            textBox3.Text = user.email;
            textBox6.Text = user.phone;
            textBox4.Text = user.password;
            textBox5.Text = user.password;
            dateTimePicker1.Text = user.date;
            textBox7.Text = user.address;
            button9.Text = user.name;
            login.Text = user.login;

            userr = user;
        }

        private void AdminEditProfilePage_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            AdminMyProfile adminmyprofile = new AdminMyProfile(userr);
            adminmyprofile.Show();
            this.Hide();
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginPage loginpage = new LoginPage();
            loginpage.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text;
            String surname = textBox2.Text;
            String email = textBox3.Text;
            String password = textBox4.Text;
            String confirmPassword = textBox5.Text;
            String phone = textBox6.Text;
            String address = textBox7.Text;
            String birthday = dateTimePicker1.Text;
            String loginn = login.Text;

            if (name.Length == 0 || surname.Length == 0 || phone.Length == 0 || address.Length == 0)
            {
                MessageBox.Show("Uzupełnij puste pola.", "BarberShop");
                return;
            }
            if ((password.Length < 5 && password.Length != 0) || (password.Length > 15 && password.Length != 0))
            {
                MessageBox.Show("Hasło musi zawierać od 5 do 15 znaków.", "BarberShop");
                return;
            }
            if (phone.Length != 9)
            {
                MessageBox.Show("Numer telefonu musi zawierać 9 znaków.", "BarberShop");
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Podane hasła są różne. Popraw dane.", "BarberShop");
                return;
            }
            if (!email.Contains('@') || !email.Contains('.'))
            {
                MessageBox.Show("Proszę wprowadzić poprawny e-mail.", "BarberShop");
                return;
            }

            try
            {
                string connectionString = "server=localhost;database=barbershop;username=root;password=;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sqlQuery = "UPDATE users SET name='" + textBox1.Text + "', surname='" + textBox2.Text + "', email='" + textBox3.Text + "', password='" + textBox4.Text + "', phone='" + textBox6.Text + "', address='" + textBox7.Text + "', birthday='" + dateTimePicker1.Text + "' WHERE login='" + login.Text + "';";
                    MySqlCommand command = new MySqlCommand(sqlQuery, conn);
                    command.ExecuteNonQuery();

                    userr.name = this.textBox1.Text;
                    userr.surname = this.textBox2.Text;
                    userr.email = this.textBox3.Text;
                    userr.password = this.textBox4.Text;
                    userr.phone = this.textBox6.Text;
                    userr.address = this.textBox7.Text;
                    userr.date = this.dateTimePicker1.Text;

                    MessageBox.Show("Pomyślnie poprawiono dane.", "BarberShop");
                    conn.Close();

                    AdminEditProfilePage admineditprofilepage = new AdminEditProfilePage(userr);
                    admineditprofilepage.Show();
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Błąd edycji konta. Popraw dane.", "BarberShop");
            }
        }
    }
}
