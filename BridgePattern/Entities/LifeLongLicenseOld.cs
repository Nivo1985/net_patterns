namespace BridgePattern.Entities;

public class LifeLongLicenseOld: LicenseOld
{
    public LifeLongLicenseOld(string name, DateTime date) : base(name, date)
    {
    }

    public override decimal GetPrice() => 100;

    public override DateTime? GetExpirationDate() => null;
}