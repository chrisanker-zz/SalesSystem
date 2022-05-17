using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace SalesSystem
{
    public class Order
        
    {
        private double ordertotal = 0;
        public double GetOrderTotalV3()
        {
            return ordertotal;
        }
        public void SetOrderTotalV3(List<Product> shoppingCart)
        {
            for (int i = 0; i < shoppingCart.Count; i++)
            {
                CultureInfo cul = new CultureInfo("en-GB");
                cul.NumberFormat.NumberDecimalSeparator = ".";
                ordertotal += Convert.ToDouble(shoppingCart[i].GetCost(shoppingCart[i].GetItemNumber()),cul);
            }
        }
    }
}