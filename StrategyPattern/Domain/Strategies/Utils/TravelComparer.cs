using System.Collections.Generic;

namespace StrategyPattern.Domain.Strategies.Utils
{
    public class TravelComparer: IComparer<TravelData>
    {
        public int Compare(TravelData x, TravelData y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}