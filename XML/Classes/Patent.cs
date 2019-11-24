using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML.Classes
{
    public class Patent
    {
        public string Name { get; set; }
        public string Inventor { get; set; }
        public string Country { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime PublicationDate { get; set; }
        public int NumberOfPage { get; set; }
        public string Note { get; set; }
    }
}
