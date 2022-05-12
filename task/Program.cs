using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace task
{
    class Program
    {
        static void Main(string[] args)
        {
            string menuChoice = "";
            List<Item> shoppingList = new List<Item>();
            List<double> unitPriceSum = new List<double>();

            //Array positions to load in list
            int a = 4;
            int b = 5;
            int c = 6;

            //So they don't have to be declared in every loop and case
            string title;
            int quantity;
            double unitPrice;

            //Reads in saved list
            string[] savedListArr = File.ReadAllLines("./data.csv");
            string savedListVar = string.Join(",", savedListArr);
            var values = savedListVar.Split(',');

            int skip = 1;
            foreach (var item in savedListArr)
            {
                //To prevent adding in headings and blank line
                if(skip <=2)
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

            while(menuChoice != "6")
            {
                Console.Write("1. Add New Item \n2. List All Items \n3. Show Total Cost \n4. Clear List \n5. Save List \n6. Exit \n\n");
                menuChoice = Console.ReadLine();
                Console.WriteLine();

                switch(menuChoice)
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
                        while (Console.ReadKey().Key != ConsoleKey.Enter){}
                        break;

                    //List All Items
                    case "2":
                        int counter = 1;
                        foreach(Item i in shoppingList)
                            {
                                if(skip <=2)
                                {
                                    skip++;
                                    continue;
                                }
                                Console.Write($"Item {counter} : {i.title}, {i.quantity}, {i.unitPrice}\n");
                                counter++;
                            }
                            Console.WriteLine();
                            Console.Write("Press 'Enter' to return to the main menu\n------------------------\n\n");
                            while (Console.ReadKey().Key != ConsoleKey.Enter){}
                        break;
                    
                    //Show Total Cost
                    case "3":
                        foreach(Item i in shoppingList)
                        {
                            unitPriceSum.Add(i.unitPrice);
                        }
                        Console.WriteLine($"The total cost is {unitPriceSum.Sum()}\n");
                        Console.Write("Press 'Enter' to return to the main menu\n------------------------\n\n");
                        while (Console.ReadKey().Key != ConsoleKey.Enter){}
                        break;

                    //Clear List
                    case "4":
                        shoppingList.Clear();
                        break;

                    //Save List
                    case "5":
                        
                        using (StreamWriter writer = new StreamWriter("./data.csv"))  
                        {  
                            writer.Write("Name, Quantity, Price\n\n");
                            foreach(Item i in shoppingList)
                            {
                                writer.Write($"{i.title}, {i.quantity}, {i.unitPrice}\n");
                            }
                            Console.WriteLine("Shopping list saved succesfully\n");
                        }
                        break;

                    //Exit
                    case "6":
                        Console.WriteLine("Thank you for using the Shopping List App");
                        break;
                }
            }
        }
    }
}
