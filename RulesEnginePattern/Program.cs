// See https://aka.ms/new-console-template for more information

using RulesEnginePattern;
using RulesEnginePattern.New;

Console.WriteLine("Hello, World!");

var discountCalculator = new DiscountCalculator();
var result =discountCalculator.CalculateDiscountPercentage(new Customer()
{
    Name = "Test Client",
    IsBloodDonor = true,
    BirthDate = new DateTime(1985,12,08)
});

Console.WriteLine(result);
