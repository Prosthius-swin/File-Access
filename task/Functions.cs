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
        public static void saveToNewFile(List<Item> shoppingList)
        {
            Console.Write("Enter shopping list name : ");
            string shoppingListName = Console.ReadLine();
            Console.WriteLine();
            using (StreamWriter writer = new StreamWriter($"./shopping-lists/{shoppingListName}.csv"))
            {
                writer.Write("Name, Quantity, Price\n\n");
                foreach (Item i in shoppingList)
                {
                    writer.Write($"{i.title}, {i.quantity}, {i.unitPrice}\n");
                }
                Console.WriteLine("Shopping list created succesfully\n");
            }
        }
    }
}