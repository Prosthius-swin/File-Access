using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace task
{
    public class Functions
    {
        public static string listSelection { get; set; }
        public static void getSavedShoppingLists(int counter, out DirectoryInfo savedShoppingLists, out FileInfo[] files, out List<string> savedShoppingListFileName, out string listSelection)
        {
            savedShoppingLists = new DirectoryInfo("./shopping-lists");
            files = savedShoppingLists.GetFiles();
            savedShoppingListFileName = new List<string>();
            listSelection = "";
            //counter = 2;
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
        //
        public static void postMenuSelection()
        {
            Console.Write("Press 'Enter' to return to the main menu\n------------------------\n\n");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }
        //
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
        //
        public static void printHorizontalLine()
        {
            Console.WriteLine("------------------------\n");
        }
        //
        public static void loadFile(List<string> savedShoppingListFileName, int listSelectionInt, List<Item> shoppingList, ref string title, ref int quantity, ref double unitPrice)
        {
            string[] savedListArr = File.ReadAllLines($"./shopping-lists/{savedShoppingListFileName[listSelectionInt]}");
            string savedListVar = string.Join(",", savedListArr);
            var values = savedListVar.Split(',');

            //Used to skip first two lines in .csv to prevent adding them to shoppingList
            int skip = 1;
            int a = 4;
            int b = 5;
            int c = 6;
            foreach (var item in savedListArr)
            {
                //To prevent adding in headings and blank line
                if (skip <= 2)
                {
                    skip++;
                    continue;
                }

                title = values[a].ToString();
                quantity = int.Parse(values[b]);
                unitPrice = double.Parse(values[c]);
                shoppingList.Add(new Item(title, quantity, unitPrice));

                a += 3;
                b += 3;
                c += 3;
            }
        }
        //
        public static void saveToCurrentFile(List<string> savedShoppingListFileName, int listSelectionInt, List<Item> shoppingList)
        {
            using (StreamWriter writer = new StreamWriter($"./shopping-lists/{savedShoppingListFileName[listSelectionInt]}"))
            {
                writer.Write("Name, Quantity, Price\n\n");
                foreach (Item i in shoppingList)
                {
                    writer.Write($"{i.title}, {i.quantity}, {i.unitPrice}\n");
                }
                Console.WriteLine("Shopping list saved succesfully\n");
            }
        }
    }
}
