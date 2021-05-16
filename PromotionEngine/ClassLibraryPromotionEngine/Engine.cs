using System.Collections.Generic;
using System.Linq;

namespace ClassLibraryPromotionEngine
{
    public class Engine
    {
        private readonly IEnumerable<SKU> PriceList;
        private readonly IEnumerable<Promotion> Promotions;

        public Engine(IEnumerable<SKU> priceList, IEnumerable<Promotion> promotions)
        {
            this.PriceList = priceList;
            this.Promotions = promotions;
        }

        public void CheckOut(Order order)
        {
            var foundItems = new List<Item>();
            if (Promotions != null && Promotions.Count() > 0)
                foreach (var promotion in Promotions)
                {
                    var validatedItems = promotion.Validate(order, foundItems);
                    UpdateValidatedItems(foundItems, validatedItems);
                }

            ApplyRegularPrice(order, foundItems);
        }

        private void ApplyRegularPrice(Order order, List<Item> foundItems)
        {
            foreach (var item in order.Items)
            {
                var validateItem = foundItems.FirstOrDefault(x => x.SKU_Id == item.SKU_Id) ?? item;
                var quantity = validateItem.Quantity;
                if (quantity > 0)
                    order.TotalAmount += quantity * PriceList.First(x => x.SKU_Id == item.SKU_Id).Unit_Price;
            }
        }

        private static void UpdateValidatedItems(List<Item> foundItems, IEnumerable<Item> validatedItems)
        {
            if (validatedItems == null || validatedItems.Count() < 1)
                return;

            foreach (var item in validatedItems)
                if (!foundItems.Any(x => x.SKU_Id == item.SKU_Id))
                    foundItems.Add(item);
        }
    }
}
