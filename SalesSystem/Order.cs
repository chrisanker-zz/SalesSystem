using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace SalesSystem
{
    public class Order
        
    {
        private double ordertotal = 0;
        public double GetOrderTotal(int itemcount)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(@"C:\Users\CAL109\source\repos\SalesSystem\SalesSystem\XMLFile1.xml");
            XmlNodeList xmlNodeList = xmlDocument.DocumentElement.SelectNodes("/productListing/productType/product[itemNumber='34961']");
            XmlNode xmlNode1 = xmlDocument.DocumentElement.SelectSingleNode("/productListing/productType/product[itemNumber='34961']");
            string str = xmlNode1.SelectSingleNode("cost").InnerText;
            return XmlConvert.ToDouble(str) * itemcount;
        }

        public double GetOrderTotalV3()
        {
            return ordertotal;
        }

        public double GetOrderTotalV2()
        {
            Product p1 = new Product("34961");
            double p1Cost = p1.GetCostV2("34961");
            Product p2 = new Product("99323140138");
            double p2Cost = p2.GetCostV2("99323140138");
            return p1Cost + p2Cost;
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