using System;
using System.Text;
using Balloons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaloonsTests
{
    [TestClass]
    public class ChartTests
    {
        [TestMethod]
        public void PrintChartTest()
        {
            Chart chartTest = new Chart();
            chartTest.AddToChart("Pesho", 15);
            chartTest.AddToChart("Pesho", 14);
            chartTest.AddToChart("Pesho", 13);
            chartTest.AddToChart("Pesho", 12);
            chartTest.AddToChart("Pesho", 11);
            chartTest.AddToChart("Pesho", 18);

            string actual = chartTest.PrintChart();

            StringBuilder sb = new StringBuilder();
            sb.Append("---------TOP FIVE CHART-----------\r\n");
            sb.Append("1.   Pesho with 15 moves.\r\n");
            sb.Append("2.   Pesho with 14 moves.\r\n");
            sb.Append("3.   Pesho with 13 moves.\r\n");
            sb.Append("4.   Pesho with 12 moves.\r\n");
            sb.Append("5.   Pesho with 11 moves.\r\n");
            sb.Append("6.   Pesho with 18 moves.\r\n");
            sb.Append("----------------------------------");
            string expected = sb.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortChartTest()
        {
            Chart chartTest = new Chart();
            chartTest.AddToChart("Pesho", 15);
            chartTest.AddToChart("Pesho", 14);
            chartTest.AddToChart("Pesho", 13);
            chartTest.AddToChart("Pesho", 12);
            chartTest.AddToChart("Pesho", 11);
            chartTest.AddToChart("Pesho", 18);

            chartTest.SortChart();
            string actual = chartTest.PrintChart();

            StringBuilder sb = new StringBuilder();
            sb.Append("---------TOP FIVE CHART-----------\r\n");
            sb.Append("1.   Pesho with 11 moves.\r\n");
            sb.Append("2.   Pesho with 12 moves.\r\n");
            sb.Append("3.   Pesho with 13 moves.\r\n");
            sb.Append("4.   Pesho with 14 moves.\r\n");
            sb.Append("5.   Pesho with 15 moves.\r\n");
            sb.Append("----------------------------------");
            string expected = sb.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GoodEnoughForChartTest()
        {
            Chart chartTest = new Chart();
            chartTest.AddToChart("Pesho", 15);
            chartTest.AddToChart("Pesho", 14);
            chartTest.AddToChart("Pesho", 13);
            chartTest.AddToChart("Pesho", 12);
            chartTest.AddToChart("Pesho", 11);
            chartTest.AddToChart("Pesho", 18);

            chartTest.SortChart();

            bool actual = chartTest.GoodEnoughForChart(19);
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GoodEnoughForChartTest2()
        {
            Chart chartTest = new Chart();
            chartTest.AddToChart("Pesho", 15);
            chartTest.AddToChart("Pesho", 14);
            chartTest.AddToChart("Pesho", 13);
            chartTest.AddToChart("Pesho", 12);
            chartTest.AddToChart("Pesho", 11);
            chartTest.AddToChart("Pesho", 18);

            chartTest.SortChart();

            bool actual = chartTest.GoodEnoughForChart(5);
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }
    }
}
