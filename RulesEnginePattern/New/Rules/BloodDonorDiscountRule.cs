namespace RulesEnginePattern.New.Rules;

public class BloodDonorDiscountRule: IDiscountRule
{
    public decimal GetDiscount(Customer customer, decimal discount)
    {
        decimal result = 0;

        if (customer.IsBloodDonor) result = .15m;
        
        return result;
    }
}