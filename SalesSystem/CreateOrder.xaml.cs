using System.Collections.Generic;
using System.Windows;

namespace SalesSystem
{
    public partial class CreateOrder : Window
    {
        int selectedProductIndex;
        public CreateOrder()
        {
            InitializeComponent();
            List<Product> shoppingCart = new List<Product>();
            Order order = new Order(shoppingCart);
        }

        private void btAddToCart_Click(object sender, RoutedEventArgs e)
        {
            lbShoppingCart.Items.Add(lbProductCatalogue.SelectedItem);
            lbProductCatalogue.Items.Remove(lbProductCatalogue.SelectedItem);
        }
    }
}