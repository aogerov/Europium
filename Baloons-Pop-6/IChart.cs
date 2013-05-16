using System;

namespace Balloons
{
    public interface IChart
    {
        bool GoodEnoughForChart(int userMoves);

        void AddToChart(int userMoves);
        
        void SortChart();
        
        string PrintChart();
    }
}
