namespace BridgePattern.Entities;

public class LifeLongLicenseNew: LicenseNew
{
   public LifeLongLicenseNew(string name, DateTime date, Discount discount) : base(name, date, discount)
    {
    }
    protected override decimal GetPriceCore() => 100;

    public override DateTime? GetExpirationDate() => null;

 
}