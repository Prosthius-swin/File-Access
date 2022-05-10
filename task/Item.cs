using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task
{
    class Item
    {
        public string title { get; set; }
        public int quantity { get; set; }
        public double unitPrice { get; set; }
        public List<Item> shoppingList = new List<Item>();

        public Item(string pTitle, int pQuantity, double pUnitPrice)
        {
            title = pTitle;
            quantity = pQuantity;
            unitPrice = pUnitPrice;    
        }    
    }
    class File
    {

    }
    /*public class StreamWriter : System.IO.TextWriter
    {
        public string filePath { get; set; }
        public StreamWriter(string pFilePath)
        {
            filePath = pFilePath;
        }
    }*/
}
