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
    public partial class AdminVisitsPage : Form
    {
        User userr = null;
        public AdminVisitsPage(User user)
        {
            InitializeComponent();
            button9.Text = user.name;
            userr = user;
            int id_user = user.id;
            userr = user;
            string connectionString = "server=localhost;database=barbershop;username=root;password=;";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string sqlQueryGetUserId = "SELECT user FROM visits WHERE user='" + id_user + "'";
            MySqlCommand commandGetUserId = new MySqlCommand(sqlQueryGetUserId, connection);
            int UserId = Convert.ToInt32(commandGetUserId.ExecuteScalar());

            MySqlCommand cmdDataBase = new MySqlCommand("SELECT DISTINCT visits.id AS 'ID WIZYTY', visits.date AS 'DATA', users.surname AS 'KLIENT', barber.name AS 'BARBER', service.name AS 'USŁUGA' FROM visits, users, barber, service WHERE user IS NOT NULL AND visits.user = users.id AND visits.barber = barber.id AND visits.service = service.id ORDER BY date ASC", connection);
            MySqlCommand cmdDataBase1 = new MySqlCommand("SELECT id FROM visits WHERE user IS NOT NULL ORDER BY id ASC", connection);
            try
            {
                //DATAGRIDVIEW
                //connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmdDataBase);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                //COMBOBOX1
                MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmdDataBase1);
                DataTable dt1 = new DataTable();
                adapter1.Fill(dt1);

                // dodanie danych do comboBox1
                comboBox1.DataSource = dt1;
                comboBox1.DisplayMember = "id";
                comboBox1.ValueMember = "id";
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

        private void AdminVisitsPage_Load(object sender, EventArgs e)
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
            AdminCreateVisitPage admincreatevisitpage = new AdminCreateVisitPage(userr);
            admincreatevisitpage.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            int id_user = userr.id;
            string id_wizyty = comboBox1.Text;

            try
            {
                string connectionString = "server=localhost;database=barbershop;username=root;password=;";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sqlQuery = "UPDATE visits SET user=NULL, barber=NULL, service=NULL WHERE id=" + id_wizyty + " AND user IS NOT NULL;";
                    MySqlCommand command = new MySqlCommand(sqlQuery, conn);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("Nie znaleziono wizyty o podanym id.", "BarberShop");
                    }
                    else
                    {
                        MessageBox.Show("Pomyślnie anulowano wizytę.", "BarberShop");
                    }

                    conn.Close();
                    AdminVisitsPage ddminvisitspage = new AdminVisitsPage(userr);
                    ddminvisitspage.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd w anulowaniu wizyty. Szczegóły błędu: " + ex.Message, "BarberShop");
            }
        }
    }
}
