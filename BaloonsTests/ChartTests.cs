using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Balloons;

namespace BaloonsTests
{
    [TestClass]
    public class ChartTests
    {
        [TestMethod]
        public void SortChartTest()
        {
            Chart testChart = new Chart();

            testChart.AddToChart(11);
            testChart.AddToChart(12);
            testChart.AddToChart(13);
            testChart.AddToChart(14);
            testChart.AddToChart(15);
            testChart.AddToChart(9);

            testChart.SortChart();
            string expected = testChart.PrintChart();

            StringBuilder sb = new StringBuilder();
            sb.Append("---------TOP FIVE CHART-----------\r\n");
            sb.Append("1.    with 9 moves.\r\n");
            sb.Append("2.    with 11 moves.\r\n");
            sb.Append("3.    with 12 moves.\r\n");
            sb.Append("4.    with 13 moves.\r\n");
            sb.Append("5.    with 14 moves.\r\n");
            sb.Append("----------------------------------");

            string actual = sb.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PrintChartTest()
        {
            Chart testChart = new Chart();

            testChart.AddToChart(11);
            testChart.AddToChart(12);
            testChart.AddToChart(13);
            testChart.AddToChart(14);
            testChart.AddToChart(15);
            testChart.AddToChart(9);

            string actual = testChart.PrintChart();

            StringBuilder sb = new StringBuilder();
            sb.Append("---------TOP FIVE CHART-----------\r\n");
            sb.Append("1.    with 11 moves.\r\n");
            sb.Append("2.    with 12 moves.\r\n");
            sb.Append("3.    with 13 moves.\r\n");
            sb.Append("4.    with 14 moves.\r\n");
            sb.Append("5.    with 15 moves.\r\n");
            sb.Append("6.    with 9 moves.\r\n");
            sb.Append("----------------------------------");

            string expected = sb.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GoodEnoughTest()
        {
            Chart testChart = new Chart();

            testChart.AddToChart(11);
            testChart.AddToChart(12);
            testChart.AddToChart(13);
            testChart.AddToChart(14);
            testChart.AddToChart(15);
            testChart.AddToChart(9);

            bool actual = testChart.GoodEnoughForChart(15);

            StringBuilder sb = new StringBuilder();
            sb.Append("---------TOP FIVE CHART-----------\r\n");
            sb.Append("1.    with 11 moves.\r\n");
            sb.Append("2.    with 12 moves.\r\n");
            sb.Append("3.    with 13 moves.\r\n");
            sb.Append("4.    with 14 moves.\r\n");
            sb.Append("5.    with 15 moves.\r\n");
            sb.Append("6.    with 9 moves.\r\n");
            sb.Append("----------------------------------");


            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GoodEnoughTest2()
        {
            Chart testChart = new Chart();

            testChart.AddToChart(11);
            testChart.AddToChart(12);
            testChart.AddToChart(13);
            testChart.AddToChart(14);
            testChart.AddToChart(15);
            testChart.AddToChart(9);

            bool actual = testChart.GoodEnoughForChart(5);

            StringBuilder sb = new StringBuilder();
            sb.Append("---------TOP FIVE CHART-----------\r\n");
            sb.Append("1.    with 11 moves.\r\n");
            sb.Append("2.    with 12 moves.\r\n");
            sb.Append("3.    with 13 moves.\r\n");
            sb.Append("4.    with 14 moves.\r\n");
            sb.Append("5.    with 15 moves.\r\n");
            sb.Append("6.    with 9 moves.\r\n");
            sb.Append("----------------------------------");


            bool expected = true;
            Assert.AreEqual(expected, actual);
        }
    }
}
