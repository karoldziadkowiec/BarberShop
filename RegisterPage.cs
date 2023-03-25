using MySql.Data.MySqlClient;
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

namespace BarberShop
{
    public partial class RegisterPage : Form
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        private void RegisterPage_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginPage loginpage = new LoginPage();
            loginpage.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text;
            String surname = textBox2.Text;
            String email = textBox3.Text;
            String login = textBox4.Text;
            String password = textBox6.Text;
            String confirmPassword = textBox5.Text;
            String phone = textBox8.Text;
            String address = textBox7.Text;
            String birthday = dateTimePicker1.Text;
            if (name.Length == 0 || surname.Length == 0 || email.Length == 0 || login.Length == 0 || password.Length == 0 || confirmPassword.Length == 0 || phone.Length == 0 || address.Length == 0 || birthday.Length == 0)
            {
                MessageBox.Show("Uzupełnij puste pola.", "BarberShop");
                return;
            }
            if (!email.Contains('@') || !email.Contains('.'))
            {
                MessageBox.Show("Proszę wprowadzić poprawny e-mail.", "BarberShop");
                return;
            }
            if ((login.Length < 5 && login.Length != 0) || (login.Length > 12 && login.Length != 0))
            {
                MessageBox.Show("Login musi zawierać od 5 do 12 znaków.", "BarberShop");
                return;
            }
            if ((password.Length < 5 && password.Length != 0) || (password.Length > 15 && password.Length != 0))
            {
                MessageBox.Show("Hasło musi zawierać od 5 do 15 znaków.", "BarberShop");
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Podane hasła są różne. Popraw dane.", "BarberShop");
                return;
            }
            if (phone.Length != 9)
            {
                MessageBox.Show("Numer telefonu musi zawierać 9 znaków.", "BarberShop");
                return;
            }
            if (!checkBox1.Checked)
            {
                MessageBox.Show("Zaakceptuj warunki regulaminu.", "BarberShop");
                return;
            }
            try
            {
                string connectionString = "server=localhost;database=barbershop;username=root;password=;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sqlQuery = "INSERT INTO users (name, surname, login, password, phone, address, email, birthday) VALUES (@name, @surname, @login, @password, @phone, @address, @email, @birthday)";     
                    MySqlCommand command = new MySqlCommand(sqlQuery, conn);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@surname", surname);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@birthday", birthday);
                    command.ExecuteNonQuery();
                    /*
                    user = new User;
                    user.name = name;
                    user.surname = surname;
                    user.email = email;
                    user.login = login;
                    user.password = password;
                    user.phone = phone;
                    user.address = address;*/
                    //commandDatabase.ExecuteReader();
                    MessageBox.Show("Pomyślnie zarejestrowano konto.", "BarberShop");
                    conn.Close();
                    LoginPage loginpage = new LoginPage();
                    loginpage.Show();
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Błąd rejestracji. Podany login posiada już konto.", "BarberShop");
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
