using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;

namespace SalesSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Thread thread = new Thread(new ThreadStart(CreateAndConfirmOrder));
        private static bool AppIsRunning;
        public MainWindow()
        {            
            InitializeComponent();
            AppIsRunning = true;
            automaticSales();
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

        private static void CreateAndConfirmOrder()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product("260406084"));
            Order order = new Order(products);
            order.WriteToLog();
        }    

        
        private static async Task automaticSales()
        {
            do
            {
                await Task.Run(() => CreateAndConfirmOrder());
                await Task.Delay(1000);
            }
            while(AppIsRunning);
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            AppIsRunning = false;
            Close();
        }
    }
}
