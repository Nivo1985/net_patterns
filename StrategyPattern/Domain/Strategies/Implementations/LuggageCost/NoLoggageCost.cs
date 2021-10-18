using StrategyPattern.Domain.Strategies.Interfaces;

namespace StrategyPattern.Domain.Strategies.Implementations.LuggageCost
{
    public class NoLuggageCost: ILuggageCost
    {
        public int GetLuggageCost(TravelData travelData) => 1;
    }
}