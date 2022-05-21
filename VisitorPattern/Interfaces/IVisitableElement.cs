namespace VisitorPattern.Interfaces;

public interface IVisitableElement
{
    void Accept(IVisitor visitor);
}