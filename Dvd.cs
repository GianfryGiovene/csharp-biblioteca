using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Dvd : Document
    {
        public int serialNumber;
        int filmDuration;

        public Dvd(int serialNumber, int filmDuration, string title, int year, string sector, string author) : base(title, year, sector, author)
        {
            this.serialNumber = serialNumber;
            this.filmDuration = filmDuration;
        }

        public Dvd(string title, int year, string sector, string author) : base(title, year, sector, author) { }
    }
}
