namespace RulesEnginePattern.New.Rules;

public class BirthdayDiscountRule: IDiscountRule
{
    public decimal GetDiscount(Customer customer, decimal discount)
    {
        var result = discount;

        if (customer.BirthDate.Day == DateTime.Now.Day && customer.BirthDate.Month == DateTime.Now.Month) result += .10m;
        
        return result;
    }
}