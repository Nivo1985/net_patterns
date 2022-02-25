using StatePattern.New;
using StatePattern.Old;

namespace StatePattern.Utils;

public static class ProcessFunctions
{
    public static async void ProcessBookingOld(OrderOld order, Action<OrderOld, OrderResult> callback, CancellationTokenSource token, OrderResult wantedResult)
    {
        try
        {
            await Task.Run(async delegate
            {
                await Task.Delay(new TimeSpan(0, 0, 1), token.Token);
            });
        }
        catch (OperationCanceledException)
        {
            callback(order, OrderResult.Cancel);
            return;
        }
        
        callback(order, wantedResult);
    }
    
    public static async void ProcessBookingNew(OrderContext orderContext, Action<OrderContext, OrderResult> callback, CancellationTokenSource token, OrderResult wantedResult)
    {
        try
        {
            await Task.Run(async delegate
            {
                await Task.Delay(new TimeSpan(0, 0, 1), token.Token);
            });
        }
        catch (OperationCanceledException)
        {
            callback(orderContext, OrderResult.Cancel);
            return;
        }
        
        callback(orderContext, wantedResult);
    }
}