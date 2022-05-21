using VisitorPattern.Entities;

namespace VisitorPattern.Interfaces;

public interface IVisitor
{
    void VisitNormalProduct(NormalProduct normalProduct);
    void VisitPremiumProduct(PremiumProduct premiumProduct);
    void Display();
}

