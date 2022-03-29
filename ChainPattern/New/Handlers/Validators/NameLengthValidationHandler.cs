using ChainPattern.Model;

namespace ChainPattern.New.Handlers.Validators;

public class NameLengthValidationHandler: Handler<Order>
{
    public override void Handle(Order order)
    {
        if (order.Name.Length < 4)
        {
            throw new Exception("Name to short");
        }
        
        base.Handle(order);
    }
}