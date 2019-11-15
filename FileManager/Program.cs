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
            bool stop = false;
            do
            {
                Console.Write("Enter command: ");
                string command = Console.ReadLine();
                string path;
                switch (command) { 
                    case "exit":
                        stop = true;
                        break;
                    case "sf":
                        Console.Write("Enter path: ");
                        path = Console.ReadLine();
                        fileSystemVisitor = new FileSystemVisitor(path);
                        break;
                    case "sfp":
                        Console.Write("Enter parameters: ");
                        Console.Write("\r\nEnter path: ");
                        path = Console.ReadLine();
                        Console.Write("\r\nEnter name: ");
                        string name = Console.ReadLine();
                        fileSystemVisitor = new FileSystemVisitor(path,name);
                        break;
                    default:
                        Console.WriteLine($"Error. Command {command} does not exist.");
                        break;
                }
                
            }
            while (stop == false);
        }
    }
}
