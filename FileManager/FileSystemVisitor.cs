using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileManager
{
    public class FileSystemVisitor
    {
        private string path;
        private List<string> fileNames = new List<string>();
        private List<string> directoriesNames = new List<string>();

        public FileSystemVisitor(string path)
        {
            this.path = path;
            ProgramEvent programEvent = new ProgramEvent();
            programEvent.SearchEvent += Start;
            programEvent.SearchEvent += DirectoryFinded;
            programEvent.SearchEvent += FilterDirectoriesFinded;
            programEvent.SearchEvent += FileFinded;
            programEvent.SearchEvent += FilterFilesFinded;
            programEvent.SearchEvent += Finish;
            programEvent.OnSearchEvent();
        }

        public void FileFinded()
        {
            if (Directory.Exists(path))
            {
                List<string> n = new List<string>();
                fileNames.AddRange(Directory.GetFiles(path).ToList());
                foreach (var name in fileNames)
                {
                    n.Add(name.Replace(path + "\\", ""));
                }
                fileNames = n;
            }
            else
            {
                Console.WriteLine("Path is incorrect.");
            }
        }

        public void DirectoryFinded()
        {
            if (Directory.Exists(path))
            {
                List<string> n = new List<string>();
                directoriesNames = Directory.GetDirectories(path).ToList();                
                foreach (var name in directoriesNames)
                {
                    n.Add(name.Replace(path + "\\", ""));
                }
                directoriesNames = n;
            }
            else
            {
                Console.WriteLine("Path is incorrect.");
            }
        }

        public void FilterFilesFinded()
        {
            Console.WriteLine("Files:");
            foreach (var name in fileNames)
            {
                if (name.Contains("pptx"))
                {
                    Console.WriteLine(name);
                    if (!Helper.YesOrNo("Next? Y/N"))
                    {
                        break;
                    }
                }
            }
        }

        public void FilterDirectoriesFinded()
        {
            Console.WriteLine("Directories:");
            string filter = null;
            bool hasFilter = Helper.YesOrNo("Do you want to filter directories? Y/N");
            if (hasFilter)
            {
                Console.WriteLine("Enter filter(directory name): ");
                filter = Console.ReadLine();
            }
            foreach (var name in directoriesNames)
            {
                if (hasFilter && !name.Contains(filter))
                {
                    continue;
                }
                Console.WriteLine(name);
                if (!Helper.YesOrNo("Next? Y/N"))
                {
                    break;
                }
            }
        }

        public void Start()
        {
            Console.WriteLine("The searching is started.");
        }

        public void Finish()
        {
            Console.WriteLine("The searching is finished.");            
        }
    }
}
