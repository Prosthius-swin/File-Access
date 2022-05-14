using System;

namespace task
{
    public class Item
    {
        public string title { get; set; }
        public int quantity { get; set; }
        public double unitPrice { get; set; }

        public Item(string pTitle, int pQuantity, double pUnitPrice)
        {
            title = pTitle;
            quantity = pQuantity;
            unitPrice = pUnitPrice;    
        }    
    }
}
