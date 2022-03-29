using ChainPattern.Model;
using ChainPattern.New.Handlers.Validators;

namespace ChainPattern.New.Utils;

public class OrderProcessorNew
{
    public bool Process(Order order)
    {
        try
        {
            var handler = new BarCodeValidationHandler();
            handler.SetNext(new DestinationRegionValidationHandler())
                   .SetNext(new NameLengthValidationHandler());

            handler.Handle(order);
        }
        catch (Exception ex)
        {
            return false;
        }

        return true;
    }
}