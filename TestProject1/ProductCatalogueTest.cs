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
        [TestMethod]
        public void RetrievesAllProductsFromCatalogue()
        {
            ProductCatalogue pc = new ProductCatalogue();            
            pc.GenerateProductCatalogue();
            Assert.AreEqual("Iso stik, Pioneer QDP3012", pc.GetProductNameAtIndex(0));
            Assert.AreEqual("Saphe One trafikalarm", pc.GetProductNameAtIndex(1));
        }
    }
}
