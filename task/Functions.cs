using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace task
{
    public class Functions
    {
        //Loads selected shopping list
        public static void listSavedShoppingLists()
        {
            List<string> savedShoppingListFileName = new List<string>();
            DirectoryInfo savedShoppingLists = new DirectoryInfo("./shopping-lists");
            FileInfo[] files = savedShoppingLists.GetFiles();
            Console.WriteLine("Select a saved shopping list or start a new list:");
            Console.WriteLine();
            Console.WriteLine("1. Start a new shopping list");

            string listSelection = "";
            int counter = 2;
            while(listSelection == "")
            {
                foreach(FileInfo i in files)
                {
                    Console.WriteLine($"{counter}. {i.Name}");
                    savedShoppingListFileName.Add(i.Name);
                    counter++;
                }
                Console.WriteLine();
                listSelection = Console.ReadLine();
            }
        }
    }
}