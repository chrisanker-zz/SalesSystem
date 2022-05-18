﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace SalesSystem
{
    public class Product
    {
        private string itemNumber;

        public Product(string itemNumber)
        {
            this.itemNumber = itemNumber;
        }

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
        internal string GetItemNumber()
        {
            return this.itemNumber;
        }
        public double GetCostV2(string itemNumber)
        {
            double cost = 0;
            var xml = XDocument.Load(@"C:\Users\CAL109\source\repos\SalesSystem\SalesSystem\XMLFile1.xml");
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
    }
}