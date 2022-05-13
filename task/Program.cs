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
            DirectoryInfo savedShoppingLists;
            FileInfo[] files;
            List<string> savedShoppingListFileName;
            string listSelection;
            int counter;
            string menu = "1. Add New Item  \n2. Show Total Cost \n3. Clear List \n4. Save List \n5. List All Items in Current List \n6. List All Saved Shopping Lists \n7. Change active list \n8. Exit \n\n";

            Console.WriteLine("Select a saved shopping list or start a new list: \n\n1. Start a new shopping list");

            //Lists all saved shopping lists
            getSavedShoppingLists(out savedShoppingLists, out files, out savedShoppingListFileName, out listSelection, out counter);
            printHorizontalLine();

            int listSelectionInt = int.Parse(listSelection) - 2;
            List<Item> shoppingList = new List<Item>();

            //So they don't have to be declared in every loop and case, with dumby data
            string title = "";
            int quantity = 1;
            double unitPrice = 1.1;
            switch (listSelectionInt + 2)
            {
                //Create new list
                case 1:
                    saveToNewFile(shoppingList);
                    postMenuSelection();
                    break;

                //Reads in saved list
                case >= 2:
                    loadFile(savedShoppingListFileName, listSelectionInt, shoppingList, ref title, ref quantity, ref unitPrice);
                    break;
            }

            string menuChoice = "";
            while (menuChoice != "8")
            {
                Console.Write(menu);
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
                        postMenuSelection();
                        break;

                    //Show Total Cost
                    case "2":
                        List<double> unitPriceSum = new List<double>();
                        foreach (Item price in shoppingList)
                        {
                            unitPriceSum.Add(price.unitPrice);
                        }
                        Console.WriteLine($"The total cost is {unitPriceSum.Sum()}\n");
                        postMenuSelection();
                        break;

                    //Clear List
                    case "3":
                        shoppingList.Clear();
                        break;

                    //Save sub-menu
                    case "4":
                        printHorizontalLine();
                        Console.WriteLine("1. Save changes to current list \n2. Save to new list \n3. Return to main menu \n");
                        string saveTypeChoice = Console.ReadLine();
                        Console.WriteLine();
                        switch (saveTypeChoice)
                        {
                            //Save changes to current list
                            case "1":
                                saveToCurrentFile(savedShoppingListFileName, listSelectionInt, shoppingList);
                                postMenuSelection();
                                break;

                            //Save to new list
                            case "2":
                                saveToNewFile(shoppingList);
                                postMenuSelection();
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
                        postMenuSelection();
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
                        postMenuSelection();
                        break;

                    //Change active list
                    case "7":
                        {
                            Console.WriteLine("Select a saved shopping list or start a new list: \n1. Start a new shopping list\n");

                            //Lists all saved shopping lists
                            getSavedShoppingLists(out savedShoppingLists, out files, out savedShoppingListFileName, out listSelection, out counter);

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

                            printHorizontalLine();

                            listSelectionInt = int.Parse(listSelection) - 2;

                            switch (listSelectionInt + 2)
                            {
                                //Create new list
                                case 1:
                                    saveToNewFile(shoppingList);
                                    postMenuSelection();
                                    break;

                                //Reads in saved list
                                case >= 2:
                                    loadFile(savedShoppingListFileName, listSelectionInt, shoppingList, ref title, ref quantity, ref unitPrice);
                                    break;
                            }
                        }
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
