using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******  Gli utenti  *******
si possono registrare al sistema, fornendo:
cognome,
nome,
email,
password,
recapito telefonico,
*/



namespace csharp_biblioteca
{
    internal class User
    {
        string surname;
        string name;
        string email;
        string password;
        string telephone;


        public User(string surname, string name, string email, string password, string telephone) :base()
        {
            this.surname = surname;
            this.name = name;
            this.email = email;
            this.password = password;
            this.telephone = telephone;
        }





        /************  OLD  ************

        public RegisteredUser(string surname, string name, string email, string password, string telephone)
        {

            this.surname = surname; 
            this.name = name;
            this.email = email;
            this.password = password;
            this.telephone = telephone;

        }

        public string ShowUserInformation()
        {
            return $"Cognome utente: {surname}\nNome utente: {name}\nEmail utente: {email}\nTelefono utente: {telephone}";
        }

        public string SearchByTitle()
        {
            Console.Write("Cerca per titolo: ");
            string titoloCercato = Console.ReadLine();

            return titoloCercato;
        }
        public int SearchByCode()
        {
            Console.Write("Cerca per codice: ");
            int codiceCercato = Int32.Parse(Console.ReadLine());

            return codiceCercato;
        }
        ************  OLD  ************/


    }
}
