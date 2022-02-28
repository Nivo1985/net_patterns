using StatePattern.Utils;

namespace StatePattern.New;

public class OrderContext
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Number { get; set; }

    private OrderState _orderState;

    public OrderContext()
    {
        MoveToOrderState(new OrderNew());
    }
    public void MoveToOrderState(OrderState orderState)
    {
        _orderState = orderState;
        _orderState.EnterState(this);
    }
    public void SubmitOrder(string name, int number, OrderResult wantedResult)
    {
        _orderState.SubmitOrder(this,name,number,OrderResult.Success);
    }
    public void Cancel()
    {
        _orderState.Cancel(this);
    }

    public void DatePassed()
    {
        _orderState.DataPassed(this);
    }
    
    
    public void ShowOrder(string orderState)
    {
        Console.WriteLine($"State:{orderState}");
        Console.WriteLine($"Id:{Id}");
        Console.WriteLine($"Name{Name}");
        Console.WriteLine($"Number{Number}");
        Console.WriteLine("========================");
    }
}