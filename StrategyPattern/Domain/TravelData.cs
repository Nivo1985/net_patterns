using System.Collections.Generic;
using StrategyPattern.Domain.Strategies.Interfaces;

namespace StrategyPattern.Domain
{
    public class TravelData
    {
        // DATA
        public string Name { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public bool ExtraLuggage { get; set; }
        public bool InnerEuTravel { get; set; }
        
        // Strategies
        public IVisaCost VisaCostCalculator { get; set; }
        public ILuggageCost LuggageCost { get; set; }
        
        // Action
        public int GetExtraCost() => VisaCostCalculator.GetVisaCost(this) + LuggageCost.GetLuggageCost(this);
    }
}