using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Document
    {
        public string title;
        int year;
        string sector;
        public bool isAvailable;
        string author;
        int shelfNumber; 

        public Document(string title, int year, string sector,string author)
        {
            this.title = title;
            this.year = year;
            this.sector = sector;
            this.author = author;
        }

        public string ReadInformation()
        {
            return $"Titolo: {title}\nAnno: {year}\nGenere: {sector}\nDisponibilità : {isAvailable}\nAutore: {author}\n\n";
        }

        
    }
}
