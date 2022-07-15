namespace RulesEnginePattern.New.Rules;

public class FirstTransactionDiscountRule: IDiscountRule
{
    public decimal GetDiscount(Customer customer, decimal discount)
    {
        decimal result = 0;

        if (customer.ClientSince == null) result = .2m;
        
        return result;
    }
}