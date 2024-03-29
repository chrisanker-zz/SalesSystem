﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SalesSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        private static bool AppIsRunning;
        double totalrevenue;
        double productrevenue;
        private StreamReader streamReader;
        private object reader;
        List<string> itemNumbers;

        public MainWindow()
        {            
            InitializeComponent();
            
            AppIsRunning = true;
            automaticSales();

            // Below doesn't work because async task is writing to same file and hence locking it

            /*streamReader = new StreamReader("SalesLog.txt");
            SalesLog salesLog = new SalesLog(streamReader, reader);
            itemNumbers = new List<string>();
            itemNumbers.Add("260406084");
            totalrevenue = salesLog.GetTotalByItem(itemNumbers);
            this.DataContext =  salesLog;*/
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
            SalesLog salesLog = new SalesLog();            
            salesLog.WriteToLog(products);
        }    

        
        private static async Task automaticSales()
        {
            try
            {
                do
                {
                    await Task.Run(() => CreateAndConfirmOrder());
                    await Task.Delay(15000);
                }
                while (AppIsRunning);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            AppIsRunning = false;
            Close();
        }

        private void tbToTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }


        private void tbFromTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
