namespace BridgePattern.Entities;

public abstract class LicenseNew
{
    public string ProductName { get; }
    public DateTime PurchaseDate { get; }

    private readonly Discount _discount;
    
    public LicenseNew( string name, DateTime date, Discount discount)
    {
        ProductName = name;
        PurchaseDate = date;
        _discount = discount;
    }

    public decimal GetPrice()
    {
        var discount = _discount.GetDiscountPrecentage();
        var multiplier = 1 - discount / 100m;
        return GetPriceCore() * multiplier;
    }
    protected abstract decimal GetPriceCore();
    public abstract DateTime? GetExpirationDate();
}