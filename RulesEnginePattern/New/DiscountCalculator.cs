namespace RulesEnginePattern.New;

public class DiscountCalculator
{
    public decimal CalculateDiscountPercentage(Customer customer)
    {
        var ruleType = typeof(IDiscountRule);
        var rules = GetType().Assembly.GetTypes()
            .Where(p => ruleType.IsAssignableFrom(p) && !p.IsInterface)
            .Select(r => Activator.CreateInstance(r) as IDiscountRule);

        var engine = new DiscountRuleEngine(rules);

        return engine.GetDiscountPercentage(customer);
    }
}