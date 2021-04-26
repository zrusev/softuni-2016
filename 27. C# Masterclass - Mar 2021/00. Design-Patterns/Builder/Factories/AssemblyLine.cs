namespace Builder.Factories
{
    public class AssemblyLine
    {
        public void Assemble(SandwichBuilder builder)
            => builder
                .AddBread()
                .AddCheese()
                .AddCondiments()
                .AddMeats()
                .AddVeggies();
    }
}