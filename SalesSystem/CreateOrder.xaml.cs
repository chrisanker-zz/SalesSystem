using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Xml.Linq;

namespace SalesSystem
{
    public partial class CreateOrder : Window
    {
        CreateOrder createOrder;
        List<string> productCatalogueListBox = new List<string>();
        List<string> ShoppingCartListBox = new List<string>();
        Order order;
        List<Product> productsInCart;
        public CreateOrder()
        {
            InitializeComponent();

            btAddToCart.IsEnabled = false;
            btRemoveFromCart.IsEnabled = false;
            btConfirm.IsEnabled = false;

            string assemblyName = Assembly.GetExecutingAssembly().Location;
            string assemblyDirectory = Path.GetDirectoryName(assemblyName);
            
            var xml = XDocument.Load(assemblyDirectory + @"\" + "XMLFile1.xml");
            var query = from c in xml.Root.Descendants("product")                        
                        select c.Element("name").Value;
            foreach (string product in query)
            {
                productCatalogueListBox.Add(product);                
            }
            lbProductCatalogue.ItemsSource = productCatalogueListBox;
            lbShoppingCart.ItemsSource = ShoppingCartListBox;
        }

        private void btAddToCart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ShoppingCartListBox.Add((string)lbProductCatalogue.SelectedItem);
                ReassignShoppingCartToItemsSource();
                productCatalogueListBox.RemoveAt(lbProductCatalogue.SelectedIndex);
                ReassignProdCatToItemsSource();
                if (productCatalogueListBox.Count == 0)
                {
                    btAddToCart.IsEnabled = false;
                }
                if (ShoppingCartListBox.Count > 0)
                {
                    btConfirm.IsEnabled = true;
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
            lbShoppingCart.ItemsSource = ShoppingCartListBox;
        }

        private void ReassignProdCatToItemsSource()
        {
            lbProductCatalogue.ItemsSource = null;
            lbProductCatalogue.ItemsSource = productCatalogueListBox;
        }

        private void btRemoveFromCart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                productCatalogueListBox.Add((string)lbShoppingCart.SelectedItem);
                ReassignProdCatToItemsSource();
                ShoppingCartListBox.RemoveAt(lbShoppingCart.SelectedIndex);
                ReassignShoppingCartToItemsSource();
                if (ShoppingCartListBox.Count == 0) { btRemoveFromCart.IsEnabled = false; btConfirm.IsEnabled = false; }
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
            try
            {
                Product product;
                productsInCart = new List<Product>();
                order = new Order(productsInCart);
                foreach (string item in ShoppingCartListBox)
                {
                    product = new Product();
                    product.GetItemNumber(item);
                    productsInCart.Add(product);
                }
                order.SetOrderTotal(productsInCart);
                ConfirmOrderMessageBox();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please add a product to the cart.", "No Product Selected");
            }
        }

        private void ConfirmOrderMessageBox()
        {
            SalesLog salesLog = new SalesLog();
            if(MessageBox.Show("Order total: " + order.GetOrderTotal() + "\nDo you wish to confirm the order?",
                            "Confirm Order",
                            MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                salesLog.WriteToLog(productsInCart);
                Close();
            }            
        }
    }
}