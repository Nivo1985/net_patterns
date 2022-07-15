namespace PrototypePattern.Old;

public class ProtorypManager
{
    private Dictionary<string, Prototype> _prototypes = new ();

    public Prototype this[string key]
    {
        get => _prototypes[key];
        set => _prototypes.Add(key, value);
    }
}