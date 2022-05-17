﻿using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace TestProject1
{
    public class Product
    {
        public string GetCost(string itemNumber)
        {
            string cost = null;            
            var xml = XDocument.Load(@"C:\Users\CAL109\source\repos\SalesSystem\SalesSystem\XMLFile1.xml");
            var query = from c in xml.Root.Descendants("product")
                        where c.Element("itemNumber").Value == itemNumber
                        select c.Element("cost").Value;
            foreach(string item in query)
            {
                cost = item;
            }
            return cost;
        }
    }
}