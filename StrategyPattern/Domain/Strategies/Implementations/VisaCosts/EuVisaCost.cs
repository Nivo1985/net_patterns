using StrategyPattern.Domain.Strategies.Interfaces;

namespace StrategyPattern.Domain.Strategies.Implementations.VisaCosts
{
    public class EuVisaCost: IVisaCost
    {
        public int GetVisaCost(TravelData travelData)
        {
            return 10;
        }
    }
}