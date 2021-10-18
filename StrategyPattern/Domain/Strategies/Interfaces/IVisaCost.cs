namespace StrategyPattern.Domain.Strategies.Interfaces
{
    public interface IVisaCost
    {
        int GetVisaCost(TravelData travelData);
    }
}