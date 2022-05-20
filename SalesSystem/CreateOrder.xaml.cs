using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Xml.Linq;

namespace SalesSystem
{
    public partial class CreateOrder : Window
    {
        List<string> productCatalogue = new List<string>();
        public CreateOrder()
        {
            InitializeComponent();            
            var xml = XDocument.Load(@"C:\Users\CAL109\source\repos\SalesSystem\SalesSystem\XMLFile1.xml");
            var query = from c in xml.Root.Descendants("product")                        
                        select c.Element("name").Value;
            foreach (string product in query)
            {
                productCatalogue.Add(product);                
            }
            lbProductCatalogue.ItemsSource = productCatalogue;
        }

        private void btAddToCart_Click(object sender, RoutedEventArgs e)
        {
            lbShoppingCart.Items.Add(lbProductCatalogue.SelectedItem);            
            productCatalogue.RemoveAt(lbProductCatalogue.SelectedIndex);
            lbProductCatalogue.ItemsSource = null;            
            lbProductCatalogue.ItemsSource = productCatalogue;
        }
    }
}