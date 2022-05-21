namespace VisitorPattern.Entities;

public class Product
{
    public int Id;
    public string Name;
    public double Price;

    public Product(int id, string name, double price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public double GetPrice(double incomeTaxRate) => Math.Round(Price * (1 + incomeTaxRate), 2);
}