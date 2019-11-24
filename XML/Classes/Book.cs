using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML.Classes
{
    public class Book
    {        
        public string Name { get; set; }
        public string Autor;
        public string City { get; set; }
        public string CompanyName { get; set; }
        public DateTime PublicationDate { get; set; }
        public int NumberOfPage { get; set; } 
        public string Note { get; set; }
        public string ISBN { get; set; }
    }
}
