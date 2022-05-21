// See https://aka.ms/new-console-template for more information

using VisitorPattern.Entities;
using VisitorPattern.Interfaces;
using VisitorPattern.VisitorClasses;

TheWay();

void TheWay()
{
    var products = new List<IVisitableElement>
    {
        new NormalProduct(1, "First Normal Product", 100),
        new NormalProduct(2, "Second Normal Product", 250),
        new PremiumProduct(3, "First Premium Product", 600),
        new PremiumProduct(4, "Second Premium Product", 700)
    };

    var priceVisitor = new PriceVisitor();
    products.ForEach(p => p.Accept(priceVisitor));
    
    priceVisitor.Display();
}