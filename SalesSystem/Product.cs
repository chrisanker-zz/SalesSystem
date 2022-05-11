using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SalesSystem
{
    [XmlRoot(ElementName="product")]
    public class Product
    {
        private int itemNumber;        
        private string type;        
        private string name;        
        private string description;
        private double cost;

        [XmlElement(ElementName = "itemNumber")]
        public int ItemNumber { get { return itemNumber; } set { itemNumber = value; } }

        [XmlElement(ElementName = "type")]
        public string Type { get { return type; } set { type = value; } }
        
        [XmlElement(ElementName = "name")]
        public string Name { get { return name; } set { name = value; } }
        
        [XmlElement(ElementName = "description")]
        public string Description { get { return description; } set { description = value; } }
        
        [XmlElement(ElementName = "cost")]
        public double Cost { get { return cost; } set { cost = value; } }

        public static List<Product> GetProducts()
        {
            return new List<Product>(new Product[2]
            {
                new Product() {ItemNumber = 1234, Type = "Spare parts", Name = "4 x 17 inch tyres", Description = "Nice winter tyres!", Cost = 3000.00},
                new Product() {ItemNumber = 54561, Type = "Spare parts", Name = "Wind shield wipers", Description = "Get that grit off your wind shield!", Cost = 1000.00}
            });            
        }        
    }
}
