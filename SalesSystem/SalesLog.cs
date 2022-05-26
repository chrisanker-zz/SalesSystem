using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows;

namespace SalesSystem
{
    public class SalesLog
    {
        private StreamReader streamReader;
        private object reader;
        private double total = 0;

        public SalesLog()
        {
        }

        public SalesLog(StreamReader sr, object reader)
        {
            streamReader = sr;
            this.reader = reader;
        }
        public double GetTotalByItem(List<string> list)
        {
            string line;            
            while ((line = streamReader.ReadLine()) != null)
            {
                for(int i = 0; i < list.Count; i++)
                {
                    if (line.Contains(list[i]))
                    {
                        string cost = line.Split(';')[2];
                        CultureInfo cul = new CultureInfo("en-GB");
                        cul.NumberFormat.NumberDecimalSeparator = ".";
                        total += Convert.ToDouble(cost, cul);                        
                    }
                }                
            }
            return total;
        }
        public void WriteToLog(List<Product> products)
        {
            string file = "SalesLog.txt";
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                for (int i = 0; i < products.Count; i++)
                {                    
                    writer.WriteLine(products[i].GetItemNumber() + "; " + products[i].GetName() + "; "
                        + products[i].GetCost(products[i].GetItemNumber()) + "; " + splitDateTime(DateTime.Now));
                }
            }
        }

        public string splitDateTime(DateTime dateTime)
        {            
            string[] dateTimeComps = dateTime.ToString().Split(" ");
            string date = dateTimeComps[0];
            string time = dateTimeComps[1];
            return dateTimeComps[0] + "; " + dateTimeComps[1];
        }
    }
}
