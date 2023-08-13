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
    public partial class AdminCreateVisitPage : Form
    {
        User userr = null;
        public AdminCreateVisitPage(User user)
        {
            InitializeComponent();

            button9.Text = user.name;
            userr = user;

            string connectionString = "server=localhost;database=barbershop;username=root;password=;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmdDataBase1 = new MySqlCommand("SELECT name FROM service", connection);
            MySqlCommand cmdDataBase2 = new MySqlCommand("SELECT name FROM barber", connection);

            try
            {
                //DATAGRIDVIEW
                connection.Open();

                //COMBOBOX1
                MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmdDataBase1);
                DataTable dt1 = new DataTable();
                adapter1.Fill(dt1);

                // dodanie danych do comboBox1
                comboBox1.DataSource = dt1;
                comboBox1.DisplayMember = "name";
                comboBox1.ValueMember = "name";

                //COMBOBOX2
                MySqlDataAdapter adapter2 = new MySqlDataAdapter(cmdDataBase2);
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);

                // dodanie danych do comboBox2
                comboBox2.DataSource = dt2;
                comboBox2.DisplayMember = "name";
                comboBox2.ValueMember = "name";
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

        private void AdminCreateVisitPage_Load(object sender, EventArgs e)
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
            AdminContactPage ddmincontactpage = new AdminContactPage(userr);
            ddmincontactpage.Show();
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
            string id_data = textBox1.Text;
            string usluga = comboBox1.Text;
            string barber = comboBox2.Text;
            int id_user = userr.id;

            if (id_data.Length == 0 || usluga.Length == 0 || barber.Length == 0 || textBox1.Text.Length == 0)
            {
                MessageBox.Show("Uzupełnij puste pola.", "BarberShop");
                return;
            }

            try
            {
                string connectionString = "server=localhost;database=barbershop;username=root;password=;";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sqlQueryGetBarberId = "SELECT id FROM barber WHERE name='" + barber + "'";
                    MySqlCommand commandGetBarberId = new MySqlCommand(sqlQueryGetBarberId, conn);
                    int barberId = Convert.ToInt32(commandGetBarberId.ExecuteScalar());

                    string sqlQueryGetServicerId = "SELECT id FROM service WHERE name='" + usluga + "'";
                    MySqlCommand commandGetServiceId = new MySqlCommand(sqlQueryGetServicerId, conn);
                    int ServiceId = Convert.ToInt32(commandGetServiceId.ExecuteScalar());

                    string sqlQuery = "UPDATE visits SET user=" + id_user + ", barber=" + barberId + ", service=" + ServiceId + " WHERE id=" + id_data + " AND user IS NULL;";
                    MySqlCommand command = new MySqlCommand(sqlQuery, conn);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("Nie znaleziono wizyty o podanej dacie.", "BarberShop");
                    }
                    else
                    {
                        MessageBox.Show("Pomyślnie zarejestrowano wizytę.", "BarberShop");
                    }

                    conn.Close();
                    AdminVisitsPage adminvisitspage = new AdminVisitsPage(userr);
                    adminvisitspage.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd w rejestracji. Wpisz poprawne dane. Szczegóły błędu: " + ex.Message, "BarberShop");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string data = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string connectionString = "server=localhost;database=barbershop;username=root;password=;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmdDataBase = new MySqlCommand("SELECT id AS 'ID WIZYTY', date AS 'DATA' FROM visits WHERE DATE(date) = @data AND user IS NULL ORDER BY date ASC", connection);
            cmdDataBase.Parameters.AddWithValue("@data", data);

            try
            {
                connection.Open();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string selectedValue = row.Cells[0].Value.ToString();
            textBox1.Text = "";
            textBox1.Text = selectedValue;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
