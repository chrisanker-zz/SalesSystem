using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesSystem;

namespace TestProject1
{
    [TestClass]
    public class OrderTest
    {
        Order order = new Order();
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
    }
}