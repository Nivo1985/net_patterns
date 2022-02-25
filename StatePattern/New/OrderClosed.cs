using StatePattern.Utils;

namespace StatePattern.New;

public class OrderClosed: OrderState
{
    private string _closeReason;

    public OrderClosed(string closeReason)
    {
        _closeReason = closeReason;
    }
    
    public override void EnterState(OrderContext orderContext)
    {
        orderContext.ShowOrder("Closed");
    }

    public override void Cancel(OrderContext orderContext)
    {
        Console.WriteLine("Invalid action in close state");
    }

    public override void DataPassed(OrderContext orderContext)
    {
        Console.WriteLine("Invalid action in close state");
    }

    public override void SubmitOrder(OrderContext orderContext, string name, int number, OrderResult wantedResult)
    {
        Console.WriteLine("Invalid action in close state");
    }
}