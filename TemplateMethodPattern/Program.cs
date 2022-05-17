// See https://aka.ms/new-console-template for more information

using TemplateMethodPattern.NewWay;
using TemplateMethodPattern.OldWay;

NewWay();


void OldWay()
{
    var goodChild = new GoodChild();
    goodChild.Start();
    Console.WriteLine(goodChild.GetStatus());

    var badChild = new BedChild();
    badChild.Start();
    Console.WriteLine(badChild.GetStatus());
}

void NewWay()
{
    var onlyChild = new NewChild();
    onlyChild.Start();
    Console.WriteLine(onlyChild.GetStatus());
}