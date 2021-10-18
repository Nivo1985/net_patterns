using StrategyPattern.Domain.Strategies.Interfaces;

namespace StrategyPattern.Domain.Strategies.Implementations.LuggageCost
{
    public class EuLuggageCost: ILuggageCost
    {
        public int GetLuggageCost(TravelData travelData) => 10;
    }
}