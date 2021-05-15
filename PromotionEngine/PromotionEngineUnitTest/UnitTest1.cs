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

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
