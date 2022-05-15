using System;
using System.Xml;

namespace SalesSystem
{
    public class Order
    {
        public double GetOrderTotal(int itemcount)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(@"C:\Users\CAL109\source\repos\SalesSystem\SalesSystem\XMLFile1.xml");
            XmlNodeList xmlNodeList = xmlDocument.DocumentElement.SelectNodes("/productListing/productType/product[itemNumber='34961']");
            XmlNode xmlNode1 = xmlDocument.DocumentElement.SelectSingleNode("/productListing/productType/product[itemNumber='34961']");
            string str = xmlNode1.SelectSingleNode("cost").InnerText;            
            return XmlConvert.ToDouble(str) * itemcount;
        }
    }
}