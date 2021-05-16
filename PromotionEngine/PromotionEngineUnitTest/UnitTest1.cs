using ClassLibraryPromotionEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PromotionEngineUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        static readonly IEnumerable<SKU> lstSKU =
            new List<SKU> 
            {
                new SKU { SKU_Id = 'A', Unit_Price = 50 },
                new SKU { SKU_Id = 'B', Unit_Price = 30 },
                new SKU { SKU_Id = 'C', Unit_Price = 20 },
                new SKU { SKU_Id = 'D', Unit_Price = 15 }
            };

        static readonly IEnumerable<Promotion> Promotions =
              new List<Promotion> 
              {
                    new Promotion 
                    {
                          Items = new List<Item> 
                          {
                            new Item { SKU_Id = 'A', Quantity = 3 }
                          },
                          TotalAmount = 130 
                    },              // 3 of A for 130
                    new Promotion 
                    {
                          Items = new List<Item> 
                          {
                            new Item { SKU_Id = 'B', Quantity = 2 }
                          },
                          TotalAmount = 45 
                    },                // 2 of B for 45
                    new Promotion 
                    {
                          Items = new List<Item> 
                          {
                            new Item { SKU_Id = 'C', Quantity = 1 },
                            new Item { SKU_Id = 'D', Quantity = 1 }
                          },
                      TotalAmount = 30 
                    }
              };                        // C + D for 30
        
        static readonly Engine actualEngine = new Engine(lstSKU, Promotions);


        [TestMethod]
        public void Test_Scenario_A()
        {
            var order =
              new Order
              {
                  Items = new List<Item>
                  {
                    new Item { SKU_Id = 'A', Quantity = 1 },
                    new Item { SKU_Id = 'B', Quantity = 1 },
                    new Item { SKU_Id = 'C', Quantity = 1 }
                  }
              };

            actualEngine.CheckOut(order);
            Assert.IsTrue(order.TotalAmount == 100);
        }
    }
}
