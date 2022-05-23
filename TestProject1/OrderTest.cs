using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesSystem;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class OrderTest
    {        
        Product product;
        Order order;
        double total;
        List<Product> shoppingCart;

        [TestInitialize]
        public void SetupForTest()
        {
            shoppingCart = new List<Product>();
            order = new Order(shoppingCart);
        }
        [TestMethod]
        public void calculateOrderTotalOneItem34961()
        {
            product = new Product("34961");            
            shoppingCart.Add(product);
            order.SetOrderTotal(shoppingCart);
            total = order.GetOrderTotal();
            Assert.AreEqual(229.00,total);
        }
        [TestMethod]
        public void calculateOrderTotalTwoItems34961()
        {
            Product p1 = new Product("34961");
            Product p2 = new Product("34961");            
            shoppingCart.Add(p1);
            shoppingCart.Add(p2);
            order.SetOrderTotal(shoppingCart);
            total = order.GetOrderTotal();
            Assert.AreEqual(458.00, total);
        }
        [TestMethod]
        public void retrievesCostForItemNumber()
        {
            double cost = 0;
            Product p1 = new Product("34961");
            Product p2 = new Product("99323140138");            
            Assert.AreEqual(229.00, p1.GetCost("34961"));            
            Assert.AreEqual(149.00, p2.GetCost("99323140138"));
        }
        [TestMethod]
        public void calculateOrderTotalOneItem34961OneItem99323140138()
        {
            Product p1 = new Product("34961");
            Product p2 = new Product("99323140138");            
            shoppingCart.Add(p1);
            shoppingCart.Add(p2);
            order.SetOrderTotal(shoppingCart);
            total = order.GetOrderTotal();
            Assert.AreEqual(378.00, total);
        }
        [TestMethod]
        public void returnsProductNameByItemNumber()
        {
            Product p1 = new Product("34961");
            Assert.AreEqual("Iso stik, Pioneer QDP3012", p1.GetName());
            Product p2 = new Product("42625");
            Assert.AreEqual("Saphe One trafikalarm", p2.GetName());
        }
        [TestMethod]
        public void removesOneSelectedProductFromCart()
        {
            shoppingCart.Add(new Product("34961"));            
            order.RemoveProduct(shoppingCart[0]);
            Assert.AreEqual(0,shoppingCart.Count);
        }
        [TestMethod]
        public void GetsItemNumberByProductName()
        {
            Product p1 = new Product();
            Assert.AreEqual("34961", p1.GetItemNumber("Iso stik, Pioneer QDP3012"));
        }
        [TestMethod]
        public void GetSalesTotalOf34961FromSalesLog()
        {
            SalesLog salesLog = new SalesLog();            
            Assert.AreEqual(598, salesLog.GetTotalByItem("34961"));
        }

    }
}
