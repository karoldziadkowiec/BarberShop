using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using MySql.Data.MySqlClient;

namespace BarberShop
{
    public partial class EditProfilePage : Form
    {
        User userr = null;
        public EditProfilePage(User user)
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
            button9.Text = "Profil: " + user.login;
            login.Text = user.login;
            userr = user;
        }

        private void EditProfilePage_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            MyProfilePage myprofilepage = new MyProfilePage(userr);
            myprofilepage.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ContactPage contactpage = new ContactPage(userr);
            contactpage.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TeamPage teampage = new TeamPage(userr);
            teampage.Show();
            this.Hide();
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginPage loginpage = new LoginPage();
            loginpage.Show();
            this.Hide();
        }

        private void login_Click(object sender, EventArgs e)
        {

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

                    userr.name= this.textBox1.Text;
                    userr.surname = this.textBox2.Text;
                    userr.email =this.textBox3.Text;
                    userr.password = this.textBox4.Text;
                    userr.phone = this.textBox6.Text;
                    userr.address = this.textBox7.Text;
                    userr.date = this.dateTimePicker1.Text;
                    
                    MessageBox.Show("Pomyślnie poprawiono dane.", "BarberShop");
                    conn.Close();
                    EditProfilePage editprofilepage = new EditProfilePage(userr);
                    editprofilepage.Show();
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Błąd edycji konta. Popraw dane.", "BarberShop");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
