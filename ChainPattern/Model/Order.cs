using System.Globalization;

namespace ChainPattern.Model;

public class Order
{
    public string Name { get; }
    public string Barcode { get; }
    public RegionInfo BuyerRegion { get; }

    public Order(string name, string barcode, RegionInfo buyerRegion)
    {
        Name = name;
        Barcode = barcode;
        BuyerRegion = buyerRegion;
    }
}