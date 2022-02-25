using StatePattern.Utils;

namespace StatePattern.New;

public class OrderNew: OrderState
{
    public override void EnterState(OrderContext orderContext)
    {
        orderContext.Id = new Random().Next();
        orderContext.ShowOrder("New");
    }

    public override void Cancel(OrderContext orderContext)
    {
        orderContext.MoveToOrderState(new OrderClosed("Order Canceled"));
    }

    public override void DataPassed(OrderContext orderContext)
    {
        orderContext.MoveToOrderState(new OrderClosed("Order Expired"));
    }

    public override void SubmitOrder(OrderContext orderContext, string name, int number, OrderResult wantedResult)
    {
        orderContext.Name = name;
        orderContext.Number = number;
        orderContext.MoveToOrderState(new OrderProcessed());
    }
}