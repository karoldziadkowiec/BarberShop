using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BarberShop
{
    public class User
    {
    public int id; 
    public string name;
	public string surname;
    public string email;
    public string login;
    public string password;
    public string phone;
    public string address;
    public string date;
        public User(int ID, string imie, string nazwisko, string Email, string Login, string Haslo, string nr, string adres, string Data)
        {
            id = ID;
            name = imie;
            surname = nazwisko;
            email = Email;
            login = Login;
            password = Haslo;
            phone = nr;
            address = adres;
            date = Data;
         }
    }
}
