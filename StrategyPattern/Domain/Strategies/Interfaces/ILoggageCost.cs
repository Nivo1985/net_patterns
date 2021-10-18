namespace StrategyPattern.Domain.Strategies.Interfaces
{
    public interface ILuggageCost
    {
        int GetLuggageCost(TravelData travelData);
    }
}