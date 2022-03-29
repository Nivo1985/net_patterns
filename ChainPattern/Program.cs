// See https://aka.ms/new-console-template for more information

using System.Globalization;
using ChainPattern.Model;
using ChainPattern.New.Utils;
using ChainPattern.Old.Utils;

Console.WriteLine("Old WAY");
OldWay();
Console.WriteLine("New WAY");
NewWay();

void OldWay()
{
    var order = new Order("Order 1", 
        "870101XXXX", 
        new RegionInfo("SE"));


    var processor = new OrderProcessorOld();

    var result = processor.Process(order);

    Console.WriteLine(result);
}

void NewWay()
{
    var order = new Order("Order 1", 
        "870101XXXX", 
        new RegionInfo("SE"));


    var processor = new OrderProcessorNew();

    var result = processor.Process(order);

    Console.WriteLine(result);
}

