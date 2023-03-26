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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace BarberShop
{
    public partial class AdminStorePage : Form
    {
        User userr = null;
        public AdminStorePage(User user)
        {
            InitializeComponent();
            button9.Text = user.name;
            userr = user;
            int id_user = user.id;
            userr = user;
            string connectionString = "server=localhost;database=barbershop;username=root;password=;";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand cmdDataBase = new MySqlCommand("SELECT id AS 'ID', name AS 'Nazwa', amount AS 'Ilość', price AS 'Cena' FROM products ORDER BY id ASC", connection);
            try
            {
                //DATAGRIDVIEW
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmdDataBase);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void AdminStorePage_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string selectedValue = row.Cells[0].Value.ToString();
            textBox1.Text = "";
            textBox1.Text = selectedValue;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string amount = numericUpDown1.Text;
            if (id.Length == 0 || amount.Length == 0)
            {
                MessageBox.Show("Wpisz poprawnie parametry.", "BarberShop");
                return;
            }
            try
            {
                string connectionString = "server=localhost;database=barbershop;username=root;password=;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sqlQuery = "UPDATE products " +
                    "SET amount=amount+'" + amount + "' " +
                    "WHERE id=@id ";
                    MySqlCommand command = new MySqlCommand(sqlQuery, conn);
                    command.Parameters.AddWithValue("@amount", amount);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Zwiększono ilość produktu w magazynie.", "BarberShop");
                    conn.Close();
                    AdminStorePage adminstorepage = new AdminStorePage(userr);
                    adminstorepage.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error. ");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string amount = numericUpDown1.Text;
            if (id.Length == 0 || amount.Length == 0)
            {
                MessageBox.Show("Wpisz poprawnie parametry.", "BarberShop");
                return;
            }
            try
            {
                string connectionString = "server=localhost;database=barbershop;username=root;password=;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sqlQuery = "UPDATE products " +
                    "SET amount=amount-'" + amount + "' " +
                    "WHERE id=@id ";
                    MySqlCommand command = new MySqlCommand(sqlQuery, conn);
                    command.Parameters.AddWithValue("@amount", amount);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Zmniejszono ilość produktu w magazynie.", "BarberShop");
                    conn.Close();
                    AdminStorePage adminstorepage = new AdminStorePage(userr);
                    adminstorepage.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error. ");
            }
        }
    }
}
