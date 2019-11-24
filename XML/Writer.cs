using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XML.Classes;

namespace XML
{
    public class Writer
    {
        public static void AddBookInFile(Book book, string path)
        {
            XDocument doc = XDocument.Load(path);
            XElement root = doc.Element("Documents");
            XElement elBook = new XElement("Book");

            XElement name = new XElement("Name",book.Name);

            XElement autor = new XElement("Autor", book.Autor);

            XElement city = new XElement("City", book.City);

            XElement companyName = new XElement("CompanyName", book.CompanyName);

            XElement publicationDate = new XElement("PublicationDate", book.PublicationDate);

            XElement numberOfPage = new XElement("NumberOfPage", book.NumberOfPage);

            XElement note = new XElement("Note", book.Note);

            XElement isbn = new XElement("ISBN", book.ISBN);

            elBook.Add(name);
            elBook.Add(autor);
            elBook.Add(city);
            elBook.Add(companyName);
            elBook.Add(publicationDate);
            elBook.Add(numberOfPage);
            elBook.Add(note);
            elBook.Add(isbn);

            root.Add(elBook);
            doc.Save(path);
            Console.WriteLine("{0} was saved in {1}",book.Name,path);
        }

        public static void CreateXml(string path,List<Book> books = null, 
            List<Magazine> magazines = null, List<Patent> patents = null)
        {
            Console.WriteLine("Begining to create document...");
            XDocument document = new XDocument();
            XElement documents = new XElement("Documents");

            if (books != null)
            {
                foreach (var book in books)
                {
                    XElement elBook = new XElement("Book",
                        new XElement("Name", book.Name),
                        new XElement("Autor", book.Autor),
                        new XElement("City", book.City),
                        new XElement("CompanyName", book.CompanyName),
                        new XElement("PublicationDate", book.PublicationDate),
                        new XElement("NumberOfPage", book.NumberOfPage),
                        new XElement("Note", book.Note),
                        new XElement("ISBN", book.ISBN)
                        );
                    documents.Add(elBook);
                }
            }

            if(magazines != null)
            {
                foreach (var magazine in magazines)
                {
                    XElement elMagazine = new XElement("Magazine", 
                        new XElement("Name", magazine.Name),
                        new XElement("City", magazine.City),
                        new XElement("CompanyName", magazine.CompanyName),
                        new XElement("PublicationDate", magazine.PublicationDate),
                        new XElement("NumberOfPage", magazine.NumberOfPage),
                        new XElement("Note", magazine.Note),
                        new XElement("Issue", magazine.Issue),
                        new XElement("Date", magazine.Date),
                        new XElement("ISSN", magazine.ISSN));
                    documents.Add(elMagazine);
                }
            }

            if (patents != null)
            {
                foreach (var patent in patents)
                {
                    XElement elPatent = new XElement("Patent", 
                        new XElement("Name", patent.Name),
                        new XElement("Inventor", patent.Inventor),
                        new XElement("Country", patent.Country),
                        new XElement("RegistrationNumber", patent.RegistrationNumber),
                        new XElement("ApplicationDate", patent.ApplicationDate),
                        new XElement("PublicationDate", patent.PublicationDate),
                        new XElement("NumberOfPage", patent.NumberOfPage),
                        new XElement("Note", patent.Note));
                    documents.Add(elPatent);
                }
            }

            document.Add(documents);
            document.Save(path);

            Console.WriteLine("Document was created in {0}",path);
        }
    }
}
