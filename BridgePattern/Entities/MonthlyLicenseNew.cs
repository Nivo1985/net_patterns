namespace BridgePattern.Entities;

public class MonthlyLicenseNew: LicenseNew
{
    public MonthlyLicenseNew(string name, DateTime date, Discount discount) : base(name, date, discount)
    {
    }

    protected override decimal GetPriceCore() => 12;

    public override DateTime? GetExpirationDate() => PurchaseDate.AddMonths(1);
}