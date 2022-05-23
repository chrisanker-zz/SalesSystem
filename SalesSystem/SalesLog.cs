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

        public SalesLog()
        {
        }

        public SalesLog(StreamReader sr, object reader)
        {
            this.streamReader = sr;
            this.reader = reader;
        }

        public double GetTotalByItem(string itemNumber)
        {
            //streamReader = new StreamReader(@"C:\Users\CAL109\source\repos\SalesSystem\SalesSystem\SalesLog.txt");
            string line;
            double total = 0;
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line.Contains(itemNumber))
                {
                    string cost = line.Split(';')[2];
                    CultureInfo cul = new CultureInfo("en-GB");
                    cul.NumberFormat.NumberDecimalSeparator = ".";
                    total += Convert.ToDouble(cost,cul);
                    Console.WriteLine(total);
                }
                
            }
            return total;
        }
    }
}
