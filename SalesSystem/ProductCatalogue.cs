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
        public List<string> ProductNames { get; set; }
        
        public void GenerateProductCatalogue()
        {
            ProductNames = new List<string>();
            var xml = XDocument.Load(@"C:\Users\CAL109\source\repos\SalesSystem\SalesSystem\XMLFile1.xml");
            var query = from c in xml.Root.Descendants("product")                        
                        select c.Element("name").Value;
            foreach (string item in query)
            {
                ProductNames.Add(item);
            }
        }

        public int GetProductCount()
        {
            return ProductNames.Count;
        }

        public string GetProductNameAtIndex(int index)
        {
            return (string)ProductNames[index];
        }
        public List<string> GetAllProducts()
        {
            return ProductNames;
        }
    }
}
