using StrategyPattern.Domain.Strategies.Interfaces;

namespace StrategyPattern.Domain.Strategies.Implementations.LuggageCost
{
    public class InternationalLuggageCost: ILuggageCost
    {
        public int GetLuggageCost(TravelData travelData)
        {
            return travelData.Destination switch
            {
                "USA" => 20,
                "China" => 25,
                _ => 5
            };
        }
    }
}