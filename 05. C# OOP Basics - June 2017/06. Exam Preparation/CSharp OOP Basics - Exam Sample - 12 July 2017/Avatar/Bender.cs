public abstract class Bender
{
    protected string Name { get; set; }
    protected int Power { get; set; }

    protected Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    public abstract double GetPower();

    public override string ToString()
    {
        string benderType = this.GetType().Name;
        int typeEnd = benderType.IndexOf("Bender");
        benderType = benderType.Insert(typeEnd, " ");

        return $"{benderType}: {this.Name}, Power: {this.Power}";
    }
}