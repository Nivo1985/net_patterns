namespace TemplateMethodPattern.OldWay;

public class OldParent
{
    private bool _isWorkingFlag = false;

    public virtual void Start() => StartProcess();

    public string GetStatus() => _isWorkingFlag ? "Working" : "Stopped";

    private void StartProcess() => _isWorkingFlag = true;
}

public class GoodChild : OldParent
{
    public override void Start()
    {
        base.Start();
        Console.WriteLine("Good child acting");
    }
}

public class BedChild : OldParent
{
    public override void Start()
    {
        Console.WriteLine("Good child acting");
    }
}