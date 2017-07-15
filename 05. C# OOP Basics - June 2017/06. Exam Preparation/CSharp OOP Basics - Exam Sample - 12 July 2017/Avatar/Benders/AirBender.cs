public class AirBender : Bender
{
    public AirBender(string name, int power, double aerialIntegrity)
        : base(name, power)
    {
        this.AerialIntegrity = aerialIntegrity;
    }

    private double aerialIntegrity;
    public double AerialIntegrity
    {
        get { return this.aerialIntegrity; }
        set { this.aerialIntegrity = value; }
    }

    public override double GetPower()
    {
        return this.AerialIntegrity * this.Power;
    }

    public override string ToString() => $"{base.ToString()}, Aerial Integrity: {this.AerialIntegrity:f2}";
}