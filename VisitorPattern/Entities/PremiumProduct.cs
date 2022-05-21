using VisitorPattern.Interfaces;

namespace VisitorPattern.Entities;

public class PremiumProduct: Product, IVisitableElement
{
    public PremiumProduct(int id, string name, double price) : base(id, name, price)
    {
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitPremiumProduct(this);
    }
}