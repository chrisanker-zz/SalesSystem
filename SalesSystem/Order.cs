using System;

namespace SalesSystem
{
    public class Order
    {
        public double GetOrderTotal(int itemcount)
        {
            return 229.00 * itemcount;
        }
    }
}