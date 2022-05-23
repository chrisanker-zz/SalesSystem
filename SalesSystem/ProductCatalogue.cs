using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SalesSystem
{
    public class ProductCatalogue
    {
        List<string> productNames = new List<string>();
        public void GenerateProductCatalogue()
        {            
            var xml = XDocument.Load(@"C:\Users\CAL109\source\repos\SalesSystem\SalesSystem\XMLFile1.xml");
            var query = from c in xml.Root.Descendants("product")                        
                        select c.Element("name").Value;
            foreach (string item in query)
            {
                productNames.Add(item);
            }
        }

        public int GetProductCount()
        {
            return productNames.Count;
        }
    }
}
