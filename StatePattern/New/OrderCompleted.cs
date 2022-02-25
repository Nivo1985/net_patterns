using StatePattern.Utils;

namespace StatePattern.New;

public class OrderCompleted: OrderState
{
    public override void EnterState(OrderContext orderContext)
    {
        orderContext.ShowOrder("Completed");
    }

    public override void Cancel(OrderContext orderContext)
    {
        orderContext.MoveToOrderState(new OrderClosed("Canceled - expect a refund"));
    }

    public override void DataPassed(OrderContext orderContext)
    {
        orderContext.MoveToOrderState(new OrderClosed("Completed - hope you are happy"));
    }

    public override void SubmitOrder(OrderContext orderContext, string name, int number, OrderResult wantedResult)
    {
        Console.WriteLine("Invalid action in complete state");
    }
}