using System;
using System.Collections.Generic;

namespace task
{
    class Program
    {
        static void Main(string[] args)
        {
            string menuChoice = "";
            List<Item> shoppingList = new List<Item>();
            while(menuChoice != "6")
            {
                Console.Write("1. Add New Item \n2. List All Items \n3. Show Total Cost \n4. Clear List \n5. Save List \n6. Exit \n\n");
                menuChoice = Console.ReadLine();
                Console.WriteLine();

                switch(menuChoice)
                {
                    case "1":
                        Console.Write("Enter item name : ");
                        string title = Console.ReadLine();

                        Console.Write("Enter quantity : ");
                        int quantity = int.Parse(Console.ReadLine());

                        Console.Write("Enter unit price : ");
                        double unitPrice = int.Parse(Console.ReadLine());

                        shoppingList.Add(new Item(title, quantity, unitPrice));
                        Console.WriteLine();

                    break;

                    case "2":
                        int counter = 1;
                        foreach(Item i in shoppingList)
                        {
                            Console.Write($"Item {counter} : {i.title}, {i.quantity}, {i.unitPrice}\n");
                            counter++;
                        }
                        Console.WriteLine();
                        break;
                }
            }
        }
        /*static public List<Item> Load()
        {
            List<Item> items = new List<Item>();
            if(File.Exists("./data.csv"))
            {
                string[] lines = File
            }
        }*/
    }
}
