using StatePattern.Utils;

namespace StatePattern.New;

public abstract class OrderState
{
    public abstract void EnterState(OrderContext orderContext);
    public abstract void Cancel(OrderContext orderContext);
    public abstract void DataPassed(OrderContext orderContext);
    public abstract void SubmitOrder(OrderContext orderContext, string name, int number, OrderResult wantedResult);
}