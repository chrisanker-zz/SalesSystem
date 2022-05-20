using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace SalesSystem
{
    public class Order
        
    {
        private double ordertotal = 0;
        private List<Product> products = new List<Product>();
        public Order(List<Product> list)
        {
            products = list;
        }
        public double GetOrderTotal()
        {
            return ordertotal;
        }
        public void SetOrderTotal(List<Product> shoppingCart)
        {
            for (int i = 0; i < shoppingCart.Count; i++)
            {
                CultureInfo cul = new CultureInfo("en-GB");
                cul.NumberFormat.NumberDecimalSeparator = ".";
                ordertotal += shoppingCart[i].GetCost(shoppingCart[i].GetItemNumber());
            }
        }
    }
}