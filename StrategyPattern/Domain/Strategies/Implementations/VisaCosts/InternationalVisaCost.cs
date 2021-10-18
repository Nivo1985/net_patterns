using StrategyPattern.Domain.Strategies.Interfaces;

namespace StrategyPattern.Domain.Strategies.Implementations.VisaCosts
{
    public class InternationalVisaCost: IVisaCost
    {
        public int GetVisaCost(TravelData travelData)
        {
            return travelData.Destination switch
            {
                "USA" => 40,
                "China" => 100,
                _ => 50
            };
        }
    }
}