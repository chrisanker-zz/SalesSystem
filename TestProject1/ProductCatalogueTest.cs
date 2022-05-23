using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SalesSystem;

namespace SalesSystemTest
{
    [TestClass]
    public class ProductCatalogueTest
    {
        [TestMethod]
        public void ProductCatalogueContains7Items()
        {
            ProductCatalogue pc = new ProductCatalogue();
            pc.GenerateProductCatalogue();
            Assert.AreEqual(7, pc.GetProductCount());
        }
    }
}
