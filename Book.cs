using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Book : Document
    {
        
        public int bookIsbn;
        int bookPages;

        public Book(int bookIsbn, int bookPages, string title, int year, string sector, string author) : base( title, year, sector, author)
        {
            this.bookIsbn = bookIsbn;
            this.bookPages = bookPages;
        }

        public Book(string title, int year, string sector, string author) : base(title, year, sector, author) { }
    
    }

    
}
