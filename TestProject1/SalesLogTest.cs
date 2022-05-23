using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SalesSystemTest
{
    [TestClass]
    public class SalesLogTest
    {
        private StreamReader streamReader;
        private object reader;
        List<string> queriedItemNumbers;
        [TestInitialize]
        public void SetupForTest()
        {
            string assemblyName = Assembly.GetExecutingAssembly().Location;
            string assemblyDirectory = Path.GetDirectoryName(assemblyName);
            streamReader = new StreamReader(assemblyDirectory + @"\" + "SalesLogTest.txt");
            queriedItemNumbers = new List<string>();
        }
        [TestMethod]
        public void GetSalesTotalOf34961FromSalesLog()
        {
            queriedItemNumbers.Add("34961");
            SalesLog salesLog = new SalesLog(streamReader, reader);
            Assert.AreEqual(458.00, salesLog.GetTotalByItem(queriedItemNumbers));
        }
        [TestMethod]
        public void GetSalesTotalOf99323140138FromSalesLog()
        {
            queriedItemNumbers.Add("99323140138");
            SalesLog salesLog = new SalesLog(streamReader, reader);
            Assert.AreEqual(149.00, salesLog.GetTotalByItem(queriedItemNumbers));
        }
        [TestMethod]
        public void GetSalesTotalOf99323140138And34961FromSalesLog()
        {            
            queriedItemNumbers.Add("99323140138");
            queriedItemNumbers.Add("34961");
            SalesLog salesLog = new SalesLog(streamReader, reader);
            Assert.AreEqual(607.00, salesLog.GetTotalByItem(queriedItemNumbers));
        }
    }
}
