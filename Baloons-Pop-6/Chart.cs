using System;
using System.Collections.Generic;
using System.Text;

namespace Balloons
{
    public class Chart : IChart
    {
        private List<KeyValuePair<string, int>> chart = new List<KeyValuePair<string, int>>();

        public bool GoodEnoughForChart(int userMoves)
        {
            if (userMoves < 1)
            {
                throw new ArgumentException("Invalid user moves count. User moves count should be bigger than 0.");
            }

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

        public void AddToChart(string userName, int userMoves)
        {
            if (userMoves < 1)
            {
                throw new ArgumentException("Invalid user moves count. User moves count should be bigger than 0.");
            }

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

        public string PrintChart()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("---------TOP FIVE CHART-----------\r\n");

            for (int i = 0; i < this.chart.Count; ++i)
            {
                KeyValuePair<string, int> currentStanding = this.chart[i];
                string line = string.Format("{0}.   {1} with {2} moves.\r\n", i + 1, currentStanding.Key, currentStanding.Value);
                sb.Append(line);
            }

            sb.Append("----------------------------------");
            return sb.ToString();
        }
    }
}
