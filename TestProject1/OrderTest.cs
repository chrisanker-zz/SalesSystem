using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesSystem;
using System;
using System.Xml;

namespace TestProject1
{
    [TestClass]
    public class OrderTest
    {
        Order order = new Order();
        Product product = new Product();
        double total;
        
        [TestMethod]
        public void calculateOrderTotalOneItem34961()
        {            
            total = order.GetOrderTotal(1);
            Assert.AreEqual(229.00,total);
        }
        [TestMethod]
        public void calculateOrderTotalTwoItems34961()
        {            
            total = order.GetOrderTotal(2);
            Assert.AreEqual(458.00, total);
        }
        [TestMethod]
        public void retrievesCostForItemNumber34961()
        {
            string cost = product.GetCost("34961");
            Assert.AreEqual("229.00", cost);
        }[TestMethod]
        public void retrievesCostForItemNumber99323140138()
        {            
            string cost = product.GetCost("99323140138");
            Assert.AreEqual("149.00", cost);
        }
    }
}
