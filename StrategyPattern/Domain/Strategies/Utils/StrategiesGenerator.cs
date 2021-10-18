using StrategyPattern.Domain.Strategies.Implementations.LuggageCost;
using StrategyPattern.Domain.Strategies.Implementations.VisaCosts;
using StrategyPattern.Domain.Strategies.Interfaces;

namespace StrategyPattern.Domain.Strategies.Utils
{
    public static class StrategiesGenerator
    {
        public static IVisaCost GetVisaCostStrategy(bool inEu)
        {
            return inEu switch
            {
                true => new EuVisaCost(),
                _ => new InternationalVisaCost()
            };
        }
        
        public static ILuggageCost GetLuggageCostStrategy(bool extraLuggage, bool inEu)
        {
            return extraLuggage switch
            {
                false => new NoLuggageCost(),
                _ => inEu switch
                {
                    true => new EuLuggageCost(),
                    _ => new InternationalLuggageCost()
                }
            };
        }
    }
}