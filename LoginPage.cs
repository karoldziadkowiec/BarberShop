using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BarberShop
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        MySqlConnection conn = new MySqlConnection("datasource=localhost;username=root;password=;database=barbershop");

        private void button7_Click(object sender, EventArgs e)
        {
            RegisterPage registerpage = new RegisterPage();
            registerpage.Show();
            this.Hide();
        }
        User user = null;
        public void button2_Click(object sender, EventArgs e)
        {
            string login, password;
            login = textBox1.Text;
            password = textBox2.Text;
            //MySqlCommand command = conn.CreateCommand();
            MySqlCommand command = new MySqlCommand();
            
            try
            {
                conn.Open();
                String querry = "SELECT * FROM users WHERE login = '" + textBox1.Text + "' AND password = '" + textBox2.Text + "'";
                
                command.CommandText = querry;
                command.Connection = conn;
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string surname = reader.GetString(2);
                        string email = reader.GetString(7);
                        login = reader.GetString(3);
                        password = reader.GetString(4);
                        string phone = reader.GetString(5);
                        string address = reader.GetString(6);
                        string date = reader.GetString(8);
                        user = new User(id, name, surname, email, login, password, phone, address, date);
                        MainPage main = new MainPage(user);
                        main.Show();
                        this.Hide();
                    }
                }
                else if (textBox1.TextLength == 0 || textBox2.TextLength == 0)
                {
                    MessageBox.Show("Puste pola logowania. Wpisz poprawne dane.", "BarberShop");
                }
                else
                {
                    MessageBox.Show("Wpisz poprawne dane logowania.", "BarberShop");
                }
            }
            catch
            {
                MessageBox.Show("Error.", "BarberShop");
            }
            finally
            {
                conn.Close();
            }

        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
