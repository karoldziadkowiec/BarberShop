using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BarberShop
{
    public partial class MyVisitsPage : Form
    {
        User userr = null;
        public MyVisitsPage(User user)
        {
            InitializeComponent();

            button9.Text = "Profil: " + user.login;
            int id_user = user.id;

            userr = user;

            string connectionString = "server=localhost;database=barbershop;username=root;password=;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string sqlQueryGetUserId = "SELECT user FROM visits WHERE user='" + id_user + "'";
            MySqlCommand commandGetUserId = new MySqlCommand(sqlQueryGetUserId, connection);
            int UserId = Convert.ToInt32(commandGetUserId.ExecuteScalar());

            MySqlCommand cmdDataBase = new MySqlCommand("SELECT visits.id AS 'ID WIZYTY', visits.date AS 'DATA', barber.name AS 'BARBER', service.name AS 'USŁUGA' FROM visits, barber, service WHERE user= " + UserId + " AND visits.barber = barber.id AND visits.service = service.id  ORDER BY date ASC", connection);
            MySqlCommand cmdDataBase1 = new MySqlCommand("SELECT id FROM visits WHERE user= " + id_user + "  ORDER BY id ASC", connection);
            
            try
            {
                //DATAGRIDVIEW
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

        private void MyVisitsPage_Load(object sender, EventArgs e)
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

        }

        private void button4_Click(object sender, EventArgs e)
        {
            EditProfilePage editprofilepage = new EditProfilePage(userr);
            editprofilepage.Show();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
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

                    MyVisitsPage myvisitspage = new MyVisitsPage(userr);
                    myvisitspage.Show();
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
