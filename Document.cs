using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Document
    {
        
        public string Title { get; private set; }
        int year;
        string sector;
        public bool IsAvailable { get; set; }
        public string takenTo;
        public string returnDate;
        string author;
        
        
        public Document(string title, int year, string sector,string author)
        {
            this.Title = title;
            this.year = year;
            this.sector = sector;
            this.author = author;
        }

        public string SetInformation()
        {
            return $"Titolo: {Title}\nAnno: {year}\nGenere: {sector}\nDisponibilità : {IsAvailable} | preso da: {takenTo} | verra restituito: {returnDate}\nAutore: {author}\n\n";
        }
    }

}
