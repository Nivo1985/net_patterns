namespace BridgePattern.Entities;

public abstract class Discount
{
    public abstract int GetDiscountPrecentage();
}

public class NoDiscount: Discount
{
    public override int GetDiscountPrecentage() => 0;
}

public class SmallDiscount : Discount
{
    public override int GetDiscountPrecentage() => 25;
}

public class BigDiscount : Discount
{
    public override int GetDiscountPrecentage() => 50;
}