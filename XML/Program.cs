using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using XML.Classes;

namespace XML
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exaple in project files XmlFiles\exaple.xml 
            Console.Write("Enter path to read xml file: ");
            string path = Console.ReadLine();

            List<Book> books = Reader.ReadBooksFromXml(path).ToList();
            List<Magazine> magazines = Reader.ReadMagazinesFromXml(path).ToList();
            List<Patent> patents = Reader.ReadPatentsFromXml(path).ToList();

            Console.Write("Enter path with name of file to save: ");
            string pathToSave = Console.ReadLine();

            Writer.CreateXml(pathToSave, books, magazines, patents);
            Book book = new Book
            {
                Name = "Зеленая миля",
                Autor = "Стивен Эдвин Кинг",
                City = "Москва",
                CompanyName = "Астрель",
                ISBN = "78-5-271-42125-9",
                Note = "Стивен Кинг приглашает читателей в жуткий мир тюремного блока смертников, откуда уходят, " +
                "чтобы не вернуться, приоткрывает дверь последнего пристанища тех, кто преступил не только человеческий, " +
                "но и Божий закон.",
                NumberOfPage = 381,
                PublicationDate = DateTime.Now
            };
            Writer.AddBookInFile(book, pathToSave);
            Console.ReadKey();
        }
    }
}
