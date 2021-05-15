namespace ClassLibraryPromotionEngine
{
    public class Item
    {
        public char SKU_Id { get; set; }
        public int Quantity { get; set; }

        public Item() { }

        public Item(Item item)
        {
            SKU_Id = item.SKU_Id;
            Quantity = item.Quantity;
        }      

        public override string ToString()
        {
            return $"{SKU_Id} {Quantity}";
        }
    }
}
