namespace Builder.Factories
{
    using Entities;

    public abstract class SandwichBuilder
    {
        protected Sandwich sandwich;

        public Sandwich Sandwich => this.sandwich;

        public abstract SandwichBuilder AddBread();
        public abstract SandwichBuilder AddMeats();
        public abstract SandwichBuilder AddCheese();
        public abstract SandwichBuilder AddVeggies();
        public abstract SandwichBuilder AddCondiments();
    }
}