namespace BridgePattern.Entities;

public class MonthlyLicenseOld: LicenseOld
{
    public MonthlyLicenseOld(string name, DateTime date) : base(name, date)
    {
    }

    public override decimal GetPrice() => 12;

    public override DateTime? GetExpirationDate() => PurchaseDate.AddMonths(1);
}