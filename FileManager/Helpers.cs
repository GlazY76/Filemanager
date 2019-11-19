using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public delegate void search();

    public class ProgramEvent
    {
        public event search SearchEvent;

        public void OnSearchEvent()
        {
            SearchEvent();
        }
    }

    public class Helper
    {
        public static bool YesOrNo(string text)
        {
            bool isStop = true;
            bool value = false;
            Console.WriteLine(text);
            do
            {
                switch (Console.ReadKey().Key.ToString())
                {
                    case "Y":
                        Console.WriteLine();
                        value = true;
                        isStop = false;
                        break;
                    case "N":
                        Console.WriteLine();
                        value = false;
                        isStop = false;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine(text);
                        break;
                }

            }
            while (isStop);
            return value;
        }
    }
}
