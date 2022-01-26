namespace BridgePattern.Entities;

public abstract class LicenseOld
{
    public string ProductName { get; }
    public DateTime PurchaseDate { get; }

    public LicenseOld( string name, DateTime date)
    {
        ProductName = name;
        PurchaseDate = date;
    }

    public abstract decimal GetPrice();
    public abstract DateTime? GetExpirationDate();
}