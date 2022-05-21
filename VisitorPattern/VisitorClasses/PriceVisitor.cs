using VisitorPattern.Entities;
using VisitorPattern.Interfaces;

namespace VisitorPattern.VisitorClasses;

public class PriceVisitor: IVisitor
{
    private double _taxPayed = 0;
    public void VisitNormalProduct(NormalProduct normalProduct)
    {
        var totalPrice = normalProduct.GetPrice(0.1);
        Console.WriteLine($"Normal Product Info ID: {normalProduct.Id}, Name: {normalProduct.Name} and the Price {totalPrice}");

        _taxPayed += totalPrice - normalProduct.Price;
    }

    public void VisitPremiumProduct(PremiumProduct premiumProduct)
    {
        var totalPrice = premiumProduct.GetPrice(0.3);
        Console.WriteLine($"Normal Product Info ID: {premiumProduct.Id}, Name: {premiumProduct.Name} and the Price {totalPrice}");

        _taxPayed += totalPrice - premiumProduct.Price;
    }

    public void Display()
    {
        Console.WriteLine($"Tax payed: {_taxPayed}");
    }
}