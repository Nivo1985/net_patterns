// See https://aka.ms/new-console-template for more information

using BridgePattern;
using BridgePattern.Entities;

NewWay();

void NewWay()
{
    var lic1 = new MonthlyLicenseNew("Soft 1", DateTime.Now, new NoDiscount());
    var lic2 = new LifeLongLicenseNew("Soft 2", DateTime.Now, new NoDiscount());
    var lic3 = new MonthlyLicenseNew("Soft 3", DateTime.Now, new SmallDiscount());
    var lic4 = new LifeLongLicenseNew("Soft 4", DateTime.Now, new BigDiscount());
}

void OldWay()
{
    var lic1 = new MonthlyLicenseOld("Soft 1", DateTime.Now);
    var lic2 = new LifeLongLicenseOld("Soft 2", DateTime.Now);
    var lic3 = new MonthlyLicenseSmallDiscountOld("Soft 3", DateTime.Now);
    var lic4 = new LifeLongLicenseBigDiscountOld("Soft 4", DateTime.Now);
    PrintLicenseOld(lic1);
    PrintLicenseOld(lic2);
    PrintLicenseOld(lic3);
    PrintLicenseOld(lic4);
    
    Console.WriteLine("_____________________________");
}

void PrintLicenseOld(LicenseOld license)
{
    Console.WriteLine($"Name: {license.ProductName}");
    Console.WriteLine($"Price: {Utils.GetPrice(license)}");
    Console.WriteLine($"Valid for: {Utils.GetValidFor(license)}");
}

void PrintLicenseNew(LicenseNew license)
{
    Console.WriteLine($"Name: {license.ProductName}");
    Console.WriteLine($"Price: {Utils.GetPrice(license)}");
    Console.WriteLine($"Valid for: {Utils.GetValidFor(license)}");
}