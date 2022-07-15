namespace RulesEnginePattern.Old;

public class OldDiscountCalculator
{
    public decimal GetDiscount(Customer customer)
    {
        decimal result = 0;

        if (customer.ClientSince == null) result = .2m;
        else if (customer.IsBloodDonor) result = .15m;
        else if (customer.ClientSince.Value < DateTime.Now.AddYears(-10)) result = .1m;
        else if (customer.ClientSince.Value < DateTime.Now.AddYears(-5)) result = .05m;
        
        if (customer.BirthDate.Day == DateTime.Now.Day && customer.BirthDate.Month == DateTime.Now.Month) result += .10m;
        
        return result;
    }
}