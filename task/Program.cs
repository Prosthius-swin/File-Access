using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
//using functions;

namespace task
{
    class Program : Functions
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select a saved shopping list or start a new list:");
            Console.WriteLine();
            Console.WriteLine("1. Start a new shopping list");

            //Lists all saved shopping lists
            DirectoryInfo savedShoppingLists = new DirectoryInfo("./shopping-lists");
            FileInfo[] files = savedShoppingLists.GetFiles();
            List<string> savedShoppingListFileName = new List<string>();
            string listSelection = "";
            int counter = 2;
            
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

            Console.WriteLine("------------------------\n");
            
            int listSelectionInt = int.Parse(listSelection) - 2;
            List<Item> shoppingList = new List<Item>();

            //So they don't have to be declared in every loop and case
            string title;
            int quantity;
            double unitPrice;
            switch (listSelectionInt + 2)
            {
                //Skip reading in list
                case 1:
                    break;

                //Reads in saved list
                case >= 2:
                    string[] savedListArr = File.ReadAllLines($"./shopping-lists/{savedShoppingListFileName[listSelectionInt]}");
                    string savedListVar = string.Join(",", savedListArr);
                    var values = savedListVar.Split(',');

                    //Used to skip first two lines in .csv to prevent adding them to shoppingList
                    int skip = 1;
                    foreach (var item in savedListArr)
                    {
                        //To prevent adding in headings and blank line
                        if (skip <= 2)
                        {
                            skip++;
                            continue;
                        }
                        int a = 4;
                        title = values[a].ToString();
                        int b = 5;
                        quantity = int.Parse(values[b]);
                        int c = 6;
                        unitPrice = double.Parse(values[c]);

                        shoppingList.Add(new Item(title, quantity, unitPrice));

                        a += 3;
                        b += 3;
                        c += 3;
                    }
                    break;
            }

            string menuChoice = "";
            while (menuChoice != "8")
            {
                Console.Write("1. Add New Item  \n2. Show Total Cost \n3. Clear List \n4. Save List \n5. List All Items in Current List \n6. List All Saved Shopping Lists \n7. Change active list \n8. Exit \n\n");
                menuChoice = Console.ReadLine();
                Console.WriteLine();

                switch (menuChoice)
                {
                    //Add New Item
                    case "1":
                        Console.Write("Enter item name : ");
                        title = Console.ReadLine();

                        Console.Write("Enter quantity : ");
                        quantity = int.Parse(Console.ReadLine());

                        Console.Write("Enter unit price : ");
                        unitPrice = int.Parse(Console.ReadLine());

                        shoppingList.Add(new Item(title, quantity, unitPrice));
                        Console.Write("\nPress 'Enter' to return to the main menu\n------------------------\n\n");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        break;

                    //Show Total Cost
                    case "2":
                        List<double> unitPriceSum = new List<double>();
                        foreach (Item price in shoppingList)
                        {
                            unitPriceSum.Add(price.unitPrice);
                        }
                        Console.WriteLine($"The total cost is {unitPriceSum.Sum()}\n");
                        Console.Write("Press 'Enter' to return to the main menu\n------------------------\n\n");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        break;

                    //Clear List
                    case "3":
                        shoppingList.Clear();
                        break;

                    //Save sub-menu
                    case "4":
                        Console.WriteLine("------------------------\n");
                        Console.WriteLine("1. Save changes to current list \n2. Save to new list \n3. Return to main menu \n");
                        string saveTypeChoice = Console.ReadLine();
                        Console.WriteLine();
                        switch(saveTypeChoice)
                        {
                            //Save changes to current list
                            case "1":
                                using (StreamWriter writer = new StreamWriter($"./shopping-lists/{savedShoppingListFileName[listSelectionInt]}"))
                                {
                                    writer.Write("Name, Quantity, Price\n\n");
                                    foreach (Item i in shoppingList)
                                    {
                                        writer.Write($"{i.title}, {i.quantity}, {i.unitPrice}\n");
                                    }
                                    Console.WriteLine("Shopping list saved succesfully\n");
                                }
                                Console.Write("Press 'Enter' to return to the main menu\n------------------------\n\n");
                                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                                break;
                            
                            //Save to new list
                            case "2":
                                Console.Write("Enter shopping list name : ");
                                string shoppingListName = Console.ReadLine();
                                using (StreamWriter writer = new StreamWriter($"./shopping-lists/{shoppingListName}.csv"))
                                {
                                    writer.Write("Name, Quantity, Price\n\n");
                                    foreach (Item i in shoppingList)
                                    {
                                        writer.Write($"{i.title}, {i.quantity}, {i.unitPrice}\n");
                                    }
                                    Console.WriteLine("Shopping list saved succesfully\n");
                                }
                                Console.Write("Press 'Enter' to return to the main menu\n------------------------\n\n");
                                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                                break;
                            
                            //Return to main menu
                            case "3":
                                break;                      
                        }
                        break;

                    //List All Items in Current List
                    case "5":
                        counter = 1;
                        foreach (Item i in shoppingList)
                        {
                            Console.Write($"Item {counter} : {i.title}, {i.quantity}, {i.unitPrice}\n");
                            counter++;
                        }
                        Console.WriteLine();
                        Console.Write("Press 'Enter' to return to the main menu\n------------------------\n\n");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        break;

                    //List All Saved Shopping Lists
                    case "6":
                        counter = 1;
                        foreach (FileInfo i in files)
                        {
                            Console.WriteLine($"{counter}. {i.Name}");
                            savedShoppingListFileName.Add(i.Name);
                            counter++;
                        }
                        Console.WriteLine("\nPress 'Enter' to return to the main menu \n------------------------\n");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        break;

                    //Change active list
                    case "7":

                        break;

                    //Exit
                    case "8":
                        Console.WriteLine("Thank you for using the Shopping List App");
                        break;
                }
            }
        }
    }
}
