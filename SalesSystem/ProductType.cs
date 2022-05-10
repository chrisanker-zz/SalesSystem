using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SalesSystem
{
    [XmlRoot(ElementName = "productType")]
    public class ProductType
    {
        [XmlElement(ElementName = "product")]
        public List<Product> Product { get; set; }

        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
