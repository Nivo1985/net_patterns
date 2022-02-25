using StatePattern.Utils;
using System.Threading;
namespace StatePattern.New;

public class OrderProcessed: OrderState
{
    private CancellationTokenSource _cancellationTokenSource;
    
    public override void EnterState(OrderContext orderContext)
    {
        _cancellationTokenSource = new CancellationTokenSource();
        
        orderContext.ShowOrder("Processed");
        ProcessFunctions.ProcessBookingNew(orderContext, ProcessingComplete, _cancellationTokenSource, OrderResult.Success);
    }

    private void ProcessingComplete(OrderContext orderContext, OrderResult orderResult)
    {
        switch (orderResult)
        {
            case OrderResult.Success:
                orderContext.MoveToOrderState(new OrderCompleted());
                break;
            case OrderResult.Fail:
                orderContext.MoveToOrderState(new OrderNew());
                break;
            case OrderResult.Cancel:
                orderContext.MoveToOrderState(new OrderClosed("Order Canceled"));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(orderResult), orderResult, null);
        }
    }

    public override void Cancel(OrderContext orderContext)
    {
        _cancellationTokenSource.Cancel();
    }

    public override void DataPassed(OrderContext orderContext)
    {
        _cancellationTokenSource.Cancel();
    }

    public override void SubmitOrder(OrderContext orderContext, string name, int number, OrderResult wantedResult)
    {
        Console.WriteLine("Invalid action in processed state");
    }
}