using StatePattern.Utils;

namespace StatePattern.Old;

public class OrderOld
{
    public OrderOld()
    {
        Id = new Random().Next();
        isNew = true;
        ShowOrder("New");
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int Number { get; set; }
    
    private CancellationTokenSource cancelToken;
    private bool isNew { get; set; }
    private bool isProcessed { get; set; }
    private bool isCompleted { get; set; }

    public void SubmitOrder(string name, int number, OrderResult wantedResult)
    {
        if (isNew)
        {
            isNew = false;
            isProcessed = true;

            Name = name;
            Number = number;

            cancelToken = new CancellationTokenSource();
            
            ProcessFunctions.ProcessBookingOld(this, OrderComplete, cancelToken, wantedResult);
            ShowOrder("Processed");
        }
    }
    
    public void Cancel()
    {
        if (isNew)
        {
            ShowOrder("Canceled by User");
            isNew = false;
        }
        else if (isProcessed)
        {
            cancelToken.Cancel();
        }
        else if (isCompleted)
        {
            ShowOrder("Canceled - expect a refund");
            isCompleted = false;
        }
        else
        {
            ShowOrder("Closed order can't be canceled");
        }
          
    }

    public void DatePassed()
    {
        if (isNew)
        {
            ShowOrder("Order Expired");
            isNew = false;
        }
        else if (isCompleted)
        {
            ShowOrder("Completed - hope you are happy");
            isCompleted = false;
        }
    }


    private void OrderComplete(OrderOld order, OrderResult result)
    {
        isProcessed = false;
        switch (result)
        {
            case OrderResult.Success:
                isCompleted = true;
                ShowOrder("Complete");
                break;
            case OrderResult.Fail:
                Name = string.Empty;
                Id = new Random().Next();
                isNew = true;
                ShowOrder("New");
                break;
            case OrderResult.Cancel:
                ShowOrder("Canceled");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(result), result, null);
        }
    }

    private void ShowOrder(string orderState)
    {
        Console.WriteLine($"State:{orderState}");
        Console.WriteLine($"Id:{Id}");
        Console.WriteLine($"Name{Name}");
        Console.WriteLine($"Number{Number}");
        Console.WriteLine("========================");
    }
}