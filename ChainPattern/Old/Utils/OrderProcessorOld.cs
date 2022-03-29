using ChainPattern.Model;
using ChainPattern.Validators;

namespace ChainPattern.Old.Utils;

public class OrderProcessorOld
{
    private BarCodeValidator _barCodeValidator = new();

    public bool Process(Order order)
    {
        if (!_barCodeValidator.Validate(order.Barcode))
        {
            return false;
        }
        else if (order.Name.Length < 4)
        {
            return false;
        }
        else if (order.BuyerRegion.TwoLetterISORegionName == "NO")
        {
            return false;
        }

        return true;
    }
}