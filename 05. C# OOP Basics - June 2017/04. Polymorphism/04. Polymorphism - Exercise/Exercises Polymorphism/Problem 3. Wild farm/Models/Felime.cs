namespace Problem_3.Wild_farm.Models
{
    public abstract class Felime : Mammal
    {
        public Felime(string name, string type, double weight,  string livingRegion) 
            : base(name, type, weight, livingRegion)
        {
        }
    }
}