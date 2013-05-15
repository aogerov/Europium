using System;
using System.Collections.Generic;

namespace Balloons
{
    public class Chart : IChart
    {
        private List<KeyValuePair<string, int>> chart = new List<KeyValuePair<string, int>>();

        public bool GoodEnoughForChart(int userMoves)
        {
            bool isForChart = false;
            
            foreach (var currentStanding in this.chart)
            {
                if (currentStanding.Value > userMoves)
                {
                    isForChart = true;
                    break;
                }
            }

            if (this.chart.Count < 5)
            {
                isForChart = true;
            }

            return isForChart;
        }

        public void AddToChart(int userMoves)
        {
            Console.WriteLine("Type in your name.");
            string userName = Console.ReadLine();
            this.chart.Add(new KeyValuePair<string, int>(userName, userMoves));
        }

        public void SortChart()
        {
            this.chart.Sort((x, y) => x.Value.CompareTo(y.Value));

            while (this.chart.Count > 5)
            {
                this.chart.RemoveAt(this.chart.Count - 1);
            }
        }

        public void PrintChart()
        {
            Console.WriteLine("---------TOP FIVE CHART-----------");

            for (int i = 0; i < this.chart.Count; ++i)
            {
                KeyValuePair<string, int> currentStanding = this.chart[i];
                Console.WriteLine("{0}.   {1} with {2} moves.", i + 1, currentStanding.Key, currentStanding.Value);
            }

            Console.WriteLine("----------------------------------");
        }
    }
}
