using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Xml.Linq;

namespace SalesSystem
{
    public partial class CreateOrder : Window
    {
        List<string> productCatalogue = new List<string>();
        List<string> shoppingCart = new List<string>();
        Order order;
        public CreateOrder()
        {
            InitializeComponent();
            btAddToCart.IsEnabled = false;
            btRemoveFromCart.IsEnabled = false;
            var xml = XDocument.Load(@"C:\Users\CAL109\source\repos\SalesSystem\SalesSystem\XMLFile1.xml");
            var query = from c in xml.Root.Descendants("product")                        
                        select c.Element("name").Value;
            foreach (string product in query)
            {
                productCatalogue.Add(product);                
            }
            lbProductCatalogue.ItemsSource = productCatalogue;
            lbShoppingCart.ItemsSource = shoppingCart;
        }

        private void btAddToCart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                shoppingCart.Add((string)lbProductCatalogue.SelectedItem);
                ReassignShoppingCartToItemsSource();
                productCatalogue.RemoveAt(lbProductCatalogue.SelectedIndex);
                ReassignProdCatToItemsSource();
                if (productCatalogue.Count == 0)
                {
                    btAddToCart.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select a product to add to cart.");                
            }
            
        }

        private void ReassignShoppingCartToItemsSource()
        {
            lbShoppingCart.ItemsSource = null;
            lbShoppingCart.ItemsSource = shoppingCart;
        }

        private void ReassignProdCatToItemsSource()
        {
            lbProductCatalogue.ItemsSource = null;
            lbProductCatalogue.ItemsSource = productCatalogue;
        }

        private void btRemoveFromCart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                productCatalogue.Add((string)lbShoppingCart.SelectedItem);
                ReassignProdCatToItemsSource();
                shoppingCart.RemoveAt(lbShoppingCart.SelectedIndex);
                ReassignShoppingCartToItemsSource();
                if (shoppingCart.Count == 0) { btRemoveFromCart.IsEnabled = false; }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please select a product to remove from cart.");
            }
        }

        private void lbProductCatalogue_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (!btAddToCart.IsEnabled) { btAddToCart.IsEnabled = true; }
        }

        private void lbShoppingCart_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if(!btRemoveFromCart.IsEnabled) { btRemoveFromCart.IsEnabled = true; }
        }

        private void btConfirm_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            List<Product> productsInCart = new List<Product>();
            product.GetItemNumber(shoppingCart[0]);
            order = new Order(productsInCart);
            productsInCart.Add(product);
            order.SetOrderTotal(productsInCart);            
            MessageBox.Show("Order total: " + order.GetOrderTotal());
        }
    }
}