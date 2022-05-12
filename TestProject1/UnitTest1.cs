using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesSystem;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void calculateOrderTotalOneItem34961()
        {
            double total;
            Order order = new Order();
            total = order.GetOrderTotal();
            Assert.AreEqual(229.00,total);
        }
    }
}
