using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemVisitor fileSystemVisitor;
            Console.WriteLine("Enter path: ");
            string path = Console.ReadLine();
            fileSystemVisitor = new FileSystemVisitor(path);
            Console.ReadKey();          
        }
    }
}
