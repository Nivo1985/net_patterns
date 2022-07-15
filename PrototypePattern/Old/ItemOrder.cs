namespace PrototypePattern.Old;

public class ItemOrder: Prototype
{
    public string Name;
    public bool SelfPickup;
    public string[] Extras;
    public Order Order;

    public ItemOrder(string name, bool selfPickup, string[] extras, Order order)
    {
        Name = name;
        SelfPickup = selfPickup;
        Extras = extras;
        Order = order;
    }

    public override Prototype ShallowCopy()
    {
        return (Prototype)MemberwiseClone();
    }

    public override Prototype DeepCopy()
    {
        var result = (ItemOrder)MemberwiseClone();
        result.Order = new Order(Order.Id);
        return result;
    }

    public override void Debug()
    {
        Console.WriteLine($"Name: {Name} SelfPickup: {SelfPickup}");
        Console.WriteLine($"Order Id: {Order.Id}");
        Console.WriteLine($"Extras: {string.Join(",", Extras)}");
        Console.WriteLine("_______________________________________");
    }
}