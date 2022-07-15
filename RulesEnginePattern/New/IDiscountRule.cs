namespace RulesEnginePattern.New;

public interface IDiscountRule
{
    public decimal GetDiscount(Customer customer, decimal discount);
}