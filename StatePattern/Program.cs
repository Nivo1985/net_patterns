// See https://aka.ms/new-console-template for more information

using StatePattern.New;
using StatePattern.Old;
using StatePattern.Utils;

Console.WriteLine("Hello, World!");
NewWay();



void NewWay()
{
    Console.WriteLine("Complete order");
    var orderComplete = new OrderContext();
    orderComplete.SubmitOrder("Order to be completed", 3, OrderResult.Success);
    Console.WriteLine("|______________________________|");
    
    Console.WriteLine("Expired order");
    var orderDelayed = new OrderContext();
    orderDelayed.DatePassed();
    Console.WriteLine("|______________________________|");
    
    Console.WriteLine("Canceled order");
    var orderCanceled = new OrderContext();
    orderCanceled.SubmitOrder("Order to be canceled", 3, OrderResult.Success);
    orderCanceled.Cancel();
    Console.WriteLine("|______________________________|");

    Console.ReadLine();
}

void OldWay()
{
    Console.WriteLine("Complete order");
    var orderComplete = new OrderOld();
    orderComplete.SubmitOrder("Order to be completed", 3, OrderResult.Success);
    Console.WriteLine("|______________________________|");
    
    Console.WriteLine("Expired order");
    var orderDelayed = new OrderOld();
    orderDelayed.DatePassed();
    Console.WriteLine("|______________________________|");
    
    Console.WriteLine("Canceled order");
    var orderCanceled = new OrderOld();
    orderCanceled.SubmitOrder("Order to be canceled", 3, OrderResult.Success);
    orderCanceled.Cancel();
    Console.WriteLine("|______________________________|");

    Console.ReadLine();
}