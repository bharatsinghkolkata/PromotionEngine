using System.Collections.Generic;

namespace ClassLibraryPromotionEngine
{
    public class Order
    {
        public List<Item> Items { get; set; }
        public double TotalAmount { get; set; }
    }
}
