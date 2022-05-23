using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

        public void RemoveProduct(Product selectedProduct)
        {
            products.Remove(selectedProduct);            
        }

        public void WriteToLog(List<Product> shoppingCart)
        {
            string filepath = @"C:\Users\CAL109\source\repos\SalesSystem\SalesSystem\SalesLog.txt";
            using (StreamWriter writer = new StreamWriter(filepath,true))
            {                
                for(int i = 0; i < shoppingCart.Count; i++)
                {
                    writer.WriteLine(shoppingCart[i].GetItemNumber() + "; " + shoppingCart[i].GetName() + "; "
                        + shoppingCart[i].GetCost(shoppingCart[i].GetItemNumber()));
                }
            }
        }        
    }
}