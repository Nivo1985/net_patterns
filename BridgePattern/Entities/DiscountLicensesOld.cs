namespace BridgePattern.Entities;

public class LifeLongLicenseSmallDiscountOld: LifeLongLicenseOld
{
    public LifeLongLicenseSmallDiscountOld(string name, DateTime date) : base(name, date)
    {
    }

    public override decimal GetPrice() => base.GetPrice()*0.75m;
}

public class LifeLongLicenseBigDiscountOld: LifeLongLicenseOld
{
    public LifeLongLicenseBigDiscountOld(string name, DateTime date) : base(name, date)
    {
    }

    public override decimal GetPrice() => base.GetPrice()*0.5m;
}

public class MonthlyLicenseSmallDiscountOld : MonthlyLicenseOld
{
    public MonthlyLicenseSmallDiscountOld(string name, DateTime date) : base(name, date)
    {
    }

    public override decimal GetPrice() => base.GetPrice()*0.75m;
}

public class MonthlyLicenseBigDiscountOld : MonthlyLicenseOld
{
    public MonthlyLicenseBigDiscountOld(string name, DateTime date) : base(name, date)
    {
    }

    public override decimal GetPrice() => base.GetPrice()*0.5m;
}