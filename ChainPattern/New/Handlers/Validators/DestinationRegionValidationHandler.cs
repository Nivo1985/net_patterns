using ChainPattern.Model;

namespace ChainPattern.New.Handlers.Validators;

public class DestinationRegionValidationHandler: Handler<Order>
{
    public override void Handle(Order order)
    {
        if (order.BuyerRegion.TwoLetterISORegionName == "NO")
        {
            throw new Exception("This region is not supported yet");
        }
        
        base.Handle(order);
    }
}