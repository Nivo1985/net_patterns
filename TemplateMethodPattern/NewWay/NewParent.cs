namespace TemplateMethodPattern.NewWay;

public abstract class NewParent
{
    private bool _isWorkingFlag = false;

    public void Start()
    {
        Before();
        StartProcess();
        After();
    }

    protected virtual void Before()
    {
    }

    protected abstract void After();
    
    public string GetStatus() => _isWorkingFlag ? "Working" : "Stopped";

    private void StartProcess() => _isWorkingFlag = true;
}

public class NewChild : NewParent
{
    protected override void Before()
    {
        base.Before();
        Console.WriteLine("Actions before");
    }

    protected override void After()
    {
        Console.WriteLine("Actions after");
    }
}