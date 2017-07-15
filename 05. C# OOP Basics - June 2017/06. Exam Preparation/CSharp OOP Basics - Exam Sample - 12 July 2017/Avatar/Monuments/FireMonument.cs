public class FireMonument : Monument
{
    public FireMonument(string name, int fireAffinity) 
        : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    private int fireAffinity;

    public int FireAffinity
    {
        get { return this.fireAffinity; }
        set { this.fireAffinity = value; }
    }

    public override int GetAffinity()
    {
        return this.FireAffinity;
    }

    public override string ToString() => $"{base.ToString()}, Fire Affinity: {FireAffinity}";
}