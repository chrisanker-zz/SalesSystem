using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;

namespace SalesSystem
{
    public class Product
    {
        private string itemNumber;
        private string name;

        public Product(string itemNumber)
        {
            this.itemNumber = itemNumber;
        }
        public Product() { }
        internal string GetItemNumber()
        {
            return this.itemNumber;
        }
        public string GetAssemblyDirectory()
        {
            string assemblyName = Assembly.GetExecutingAssembly().Location;
            string assemblyDirectory = Path.GetDirectoryName(assemblyName);
            return assemblyDirectory;
        }
        public double GetCost(string itemNumber)
        {            
            double cost = 0;
            var xml = XDocument.Load(GetAssemblyDirectory() + @"\" + "XMLFile1.xml");
            var query = from c in xml.Root.Descendants("product")
                        where c.Element("itemNumber").Value == itemNumber
                        select c.Element("cost").Value;
            foreach (string item in query)
            {
                CultureInfo cul = new CultureInfo("en-GB");
                cul.NumberFormat.NumberDecimalSeparator = ".";
                cost = Convert.ToDouble(item,cul);
            }
            return cost;
        }

        public string GetName()
        {
            var xml = XDocument.Load(GetAssemblyDirectory() + @"\" + "XMLFile1.xml");
            var query = from c in xml.Root.Descendants("product")
                        where c.Element("itemNumber").Value == itemNumber
                        select c.Element("name").Value;
            foreach (string item in query)
            {
                name = item;
            }
            return name;
        }

        public string GetItemNumber(string productName)
        {
            var xml = XDocument.Load(GetAssemblyDirectory() + @"\" + "XMLFile1.xml");
            var query = from c in xml.Root.Descendants("product")
                        where c.Element("name").Value == productName
                        select c.Element("itemNumber").Value;
            foreach (string item in query)
            {
                itemNumber = item;
            }
            return itemNumber;         
        }
    }
}