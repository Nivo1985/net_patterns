// See https://aka.ms/new-console-template for more information

using PrototypePattern.Old;


var prototypeManager = new ProtorypManager();

prototypeManager["order1"] = new ItemOrder("original", true, new[] { "Extras2" }, new Order(1));

var shallowCopyObject = (ItemOrder)prototypeManager["order1"].ShallowCopy();
var deepCopyObject = (ItemOrder)prototypeManager["order1"].DeepCopy();

((ItemOrder)prototypeManager["order1"]).Order.Id = 2;

Console.WriteLine("Original");
((ItemOrder)prototypeManager["order1"]).Debug();

Console.WriteLine("Shallow Copy");
shallowCopyObject.Debug();

Console.WriteLine("Deep Copy");
deepCopyObject.Debug();

Console.ReadKey();