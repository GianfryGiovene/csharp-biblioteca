using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class RegisteredUser
    {
        string surname;
        string name;
        string email;
        string password;
        string telephone;

        public RegisteredUser(string surname, string name, string email, string password, string telephone)
        {

            this.surname = surname; 
            this.name = name;
            this.email = email;
            this.password = password;
            this.telephone = telephone;

        }

        public Loan getALoan(Document document)
        {
            if (document.isAvailable)
            {

                Loan loan = new Loan(this, document);

                return loan;
            }
            return null;
            
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


    }
}
