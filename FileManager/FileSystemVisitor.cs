using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileManager
{
    public class FileSystemVisitor
    {
        delegate void search();
        string path;
        string name;
        List<string> names = new List<string>();

        public FileSystemVisitor(string path)
        {
            this.path = path;
            search search;
            search = FindFilesAndDirectories;
            search += ShowFileTree;
            search();
        }

        public FileSystemVisitor(string path,string name)
        {
            this.path = path;
            this.name = name;
            search search;
            search = FindFilesAndDirectories;
            search += FilterByNameInDirectory;
            search += ShowFileTree;
            search();
        }

        public void ShowFileTree()
        {
            Console.WriteLine($"\r\nAll directories and files in {path}");
            foreach (var name in names)
            {                              
                Console.WriteLine("\t" + name);
            }
            Console.WriteLine("The searching is finished.");
        }

        public void FindFilesAndDirectories()
        {
            Console.WriteLine("Started searching...");
            if (Directory.Exists(path))
            {
                List<string> n = new List<string>();
                names = Directory.GetDirectories(path).ToList();
                names.AddRange(Directory.GetFiles(path).ToList());
                foreach (var name in names)
                {
                    n.Add(name.Replace(path + "\\", ""));
                }
                names = n;
            }
            else
            {
                Console.WriteLine("Path is incorrect.");
            }
        }

        public void FilterByNameInDirectory()
        {
            names = names.Where(n => n.Contains(name)).ToList();
        }


    }
}
