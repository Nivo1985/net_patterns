namespace BridgePattern.Entities;

public abstract class LicenseOld
{
    public string ProductName { get; }
    protected DateTime PurchaseDate { get; }

    protected LicenseOld(string name, DateTime date)
    {
        ProductName = name;
        PurchaseDate = date;
    }

    public abstract decimal GetPrice();
    public abstract DateTime? GetExpirationDate();
}