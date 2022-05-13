using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace task
{
    public class Functions
    {
        public static string listSelection { get; set; }
        public static void getSavedShoppingLists(out DirectoryInfo savedShoppingLists, out FileInfo[] files, out List<string> savedShoppingListFileName, out string listSelection, out int counter)
        {
            savedShoppingLists = new DirectoryInfo("./shopping-lists");
            files = savedShoppingLists.GetFiles();
            savedShoppingListFileName = new List<string>();
            listSelection = "";
            counter = 2;
            while (listSelection == "")
            {
                foreach (FileInfo i in files)
                {
                    Console.WriteLine($"{counter}. {i.Name}");
                    savedShoppingListFileName.Add(i.Name);
                    counter++;
                }
                Console.WriteLine();
                listSelection = Console.ReadLine();
            }
        }
        public static void postMenuSelection()
        {
            Console.Write("Press 'Enter' to return to the main menu\n------------------------\n\n");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }
    }
}