using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Loan
    {
        RegisteredUser user;
        Document document;

        public Loan(RegisteredUser user, Document document)
        {
            this.user = user;
            this.document = document;
        }
    }
}
