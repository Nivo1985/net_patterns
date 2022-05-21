using VisitorPattern.Interfaces;

namespace VisitorPattern.Entities;

public class NormalProduct: Product, IVisitableElement
{
    public NormalProduct(int id, string name, double price) : base(id, name, price)
    {
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitNormalProduct(this);
    }
}