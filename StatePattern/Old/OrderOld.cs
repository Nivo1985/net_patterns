using StatePattern.Utils;

namespace StatePattern.Old;

public class OrderOld
{
    public OrderOld()
    {
        Id = new Random().Next();
        IsNew = true;
        ShowOrder("New");
    }

    private int Id { get; set; }
    private string Name { get; set; }
    private int Number { get; set; }
    
    private CancellationTokenSource _cancelToken;
    private bool IsNew { get; set; }
    private bool IsProcessed { get; set; }
    private bool IsCompleted { get; set; }

    public void SubmitOrder(string name, int number, OrderResult wantedResult)
    {
        if (IsNew)
        {
            IsNew = false;
            IsProcessed = true;

            Name = name;
            Number = number;

            _cancelToken = new();
            
            ProcessFunctions.ProcessBookingOld(this, OrderComplete, _cancelToken, wantedResult);
            ShowOrder("Processed");
        }
    }
    
    public void Cancel()
    {
        if (IsNew)
        {
            ShowOrder("Canceled by User");
            IsNew = false;
        }
        else if (IsProcessed)
        {
            _cancelToken.Cancel();
        }
        else if (IsCompleted)
        {
            ShowOrder("Canceled - expect a refund");
            IsCompleted = false;
        }
        else
        {
            ShowOrder("Closed order can't be canceled");
        }
          
    }

    public void DatePassed()
    {
        if (IsNew)
        {
            ShowOrder("Order Expired");
            IsNew = false;
        }
        else if (IsCompleted)
        {
            ShowOrder("Completed - hope you are happy");
            IsCompleted = false;
        }
    }


    private void OrderComplete(OrderOld order, OrderResult result)
    {
        IsProcessed = false;
        switch (result)
        {
            case OrderResult.Success:
                IsCompleted = true;
                ShowOrder("Complete");
                break;
            case OrderResult.Fail:
                Name = string.Empty;
                Id = new Random().Next();
                IsNew = true;
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