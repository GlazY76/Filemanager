using System;
using System.Collections.Generic;
using System.Xml;
using XML.Classes;

namespace XML
{
    public class Reader
    {
        public static IEnumerable<Book> ReadBooksFromXml(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode node = doc.DocumentElement;
            foreach (XmlNode xnode in node)
            {
                Book book = new Book();
                if (xnode.Name != "Book")
                {
                    continue;
                }
                foreach (XmlElement childNode in xnode)
                {
                    switch (childNode.Name)
                    {
                        case "Name":
                            book.Name = childNode.InnerText;
                            break;
                        case "Autor":
                            book.Autor = childNode.InnerText;
                            break;
                        case "City":
                            book.City = childNode.InnerText;
                            break;
                        case "CompanyName":
                            book.CompanyName = childNode.InnerText;
                            break;
                        case "PublicationDate":
                            book.PublicationDate = DateTime.Parse(childNode.InnerText);
                            break;
                        case "NumberOfPage":
                            int.TryParse(childNode.InnerText,out int num);
                            book.NumberOfPage = num;
                            break;
                        case "Note":
                            book.Note = childNode.InnerText;
                            break;
                        case "ISBN":
                            book.ISBN = childNode.InnerText;
                            break;
                    }
                }
                yield return book;
            }
        }

        public static IEnumerable<Patent> ReadPatentsFromXml(string path)
        {
            Patent patent = new Patent();
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode node = doc.DocumentElement;
            foreach (XmlNode xnode in node)
            {
                if (xnode.Name != "Patent")
                {
                    continue;
                }
                foreach (XmlElement childNode in xnode)
                {
                    switch (childNode.Name)
                    {
                        case "Name":
                            patent.Name = childNode.InnerText;
                            break;
                        case "Inventor":
                            patent.Inventor = childNode.InnerText;
                            break;
                        case "Country":
                            patent.Country = childNode.InnerText;
                            break;
                        case "ApplicationDate":
                            patent.ApplicationDate = DateTime.Parse(childNode.InnerText);
                            break;
                        case "PublicationDate":
                            patent.PublicationDate = DateTime.Parse(childNode.InnerText);
                            break;
                        case "NumberOfPage":
                            int.TryParse(childNode.InnerText, out int num);
                            patent.NumberOfPage = num;
                            break;
                        case "Note":
                            patent.Note = childNode.InnerText;
                            break;
                        case "RegistrationNumber":
                            patent.RegistrationNumber = childNode.InnerText;
                            break;
                    }
                }
                yield return patent;
            }
        }

        public static IEnumerable<Magazine> ReadMagazinesFromXml(string path)
        {
            Magazine magazine = new Magazine();
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode node = doc.DocumentElement;
            foreach (XmlNode xnode in node)
            {
                if (xnode.Name != "Magazine")
                {
                    continue;
                }
                foreach (XmlElement childNode in xnode)
                {
                    switch (childNode.Name)
                    {
                        case "Name":
                            magazine.Name = childNode.InnerText;
                            break;
                        case "CompanyName":
                            magazine.CompanyName = childNode.InnerText;
                            break;
                        case "City":
                            magazine.City = childNode.InnerText;
                            break;
                        case "Date":
                            magazine.Date = DateTime.Parse(childNode.InnerText);
                            break;
                        case "PublicationDate":
                            magazine.PublicationDate = DateTime.Parse(childNode.InnerText);
                            break;
                        case "NumberOfPage":
                            int.TryParse(childNode.InnerText, out int num);
                            magazine.NumberOfPage = num;
                            break;
                        case "Note":
                            magazine.Note = childNode.InnerText;
                            break;
                        case "Issue":
                            int.TryParse(childNode.InnerText, out int issue);
                            magazine.Issue = issue;
                            break;
                        case "ISSN":
                            magazine.ISSN = childNode.InnerText;
                            break;
                    }
                }
                yield return magazine;
            }
        }
    }
}
