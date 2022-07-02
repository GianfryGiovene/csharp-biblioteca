using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Rent
    {
        /************  OLD  ************
        RegisteredUser user;
        Document document;

        string dateStartLoan;
        string dateEndLoan;

        public Loan(RegisteredUser user, Document document)
        {
            this.user = user;
            this.document = document;
        }

        public void LoanTime()
        {
            Console.WriteLine("Per quanto tempo vuoi tenerlo? ");
            Console.Write("Inizio prestito(inserire una data nel formato gg/mm/A: ");
            string dateStartLoan = Console.ReadLine();

            Console.Write("Fine prestito(inserire una data nel formato gg/mm/A: ");
            string dateEndLoan = Console.ReadLine();

            Console.WriteLine("Il prestito inizerà in data {0} e dovrà essere restituito in data {1} confermare? y(es) o n(ot)", dateStartLoan, dateEndLoan);

            char validator = char.Parse(Console.ReadLine());
            if (validator == 'y')
            {
                document.returnDate = dateEndLoan;
                document.takenFrom = $"cognome: {this.user.surname}, nome: {this.user.name}";
                document.isAvailable = false;
                Console.WriteLine( $"inizio prestito in {dateStartLoan}, fine prestito in {dateEndLoan}");

            } 
        }
        ************  OLD  ************/
        
    }
}
