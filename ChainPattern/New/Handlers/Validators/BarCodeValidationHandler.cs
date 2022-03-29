using ChainPattern.Model;
using ChainPattern.Validators;

namespace ChainPattern.New.Handlers.Validators;
public class BarCodeValidationHandler: Handler<Order>
{
    private BarCodeValidator _barCodeValidator = new();
    
    public override void Handle(Order order)
    {
        if (!_barCodeValidator.Validate(order.Barcode))
        {
            throw new Exception("Bar code is not valid");
        }
        
        base.Handle(order);
    }
}