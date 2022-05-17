using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesSystem;
using System;
using System.Collections.Generic;
using System.Xml;

namespace TestProject1
{
    [TestClass]
    public class OrderTest
    {
        Order order = new Order();
        Product product;
        double total;
        
        [TestMethod]
        public void calculateOrderTotalOneItem34961()
        {
            product = new Product("34961");
            List<Product> shoppingCart = new List<Product>();
            shoppingCart.Add(product);
            order.SetOrderTotalV3(shoppingCart);
            total = order.GetOrderTotalV3();
            Assert.AreEqual(229.00,total);
        }
        [TestMethod]
        public void calculateOrderTotalTwoItems34961()
        {
            Product p1 = new Product("34961");
            Product p2 = new Product("34961");
            List<Product> shoppingCart = new List<Product>();
            shoppingCart.Add(p1);
            shoppingCart.Add(p2);
            order.SetOrderTotalV3(shoppingCart);
            total = order.GetOrderTotalV3();
            Assert.AreEqual(458.00, total);
        }
        [TestMethod]
        public void retrievesCostForItemNumber()
        {
            string cost = null;
            Product p1 = new Product("34961");
            Product p2 = new Product("99323140138");
            cost = p1.GetCost("34961");
            Assert.AreEqual("229.00", cost);
            cost = p2.GetCost("99323140138");
            Assert.AreEqual("149.00", cost);
        }
        [TestMethod]
        public void calculateOrderTotalOneItem34961OneItem99323140138()
        {
            Product p1 = new Product("34961");
            Product p2 = new Product("99323140138");
            List<Product> shoppingCart = new List<Product>();
            shoppingCart.Add(p1);
            shoppingCart.Add(p2);
            order.SetOrderTotalV3(shoppingCart);
            total = order.GetOrderTotalV3();
            Assert.AreEqual(378.00, total);
        }
    }
}
