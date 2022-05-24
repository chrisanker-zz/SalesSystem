using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        static void CallWriteToLogMethod()
        {
            List<Product> products = new List<Product>();
            Order order = new Order(products);
            products.Add(new Product("34961"));
            order.WriteToLog();
        }
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgSalesOverview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            CreateOrder createOrder = new CreateOrder();
            createOrder.ShowDialog();
        }

        private void ListBoxItem_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }
    }
}
