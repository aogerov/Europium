using System;

namespace Balloons
{
    public interface IChart
    {
        bool GoodEnoughForChart(int userMoves);

        void AddToChart(string userName, int userMoves);
        
        void SortChart();
        
        string PrintChart();
    }
}
