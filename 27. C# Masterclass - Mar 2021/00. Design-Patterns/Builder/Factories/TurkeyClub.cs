namespace Builder.Factories
{
    using Entities;

    public class TurkeyClub : SandwichBuilder
    {
        public TurkeyClub()
            => this.sandwich = new Sandwich("Turkey Club");

        public override SandwichBuilder AddBread()
        {
            sandwich["bread"] = "12-Grain";

            return this;
        }

        public override SandwichBuilder AddCheese()
        {
            sandwich["cheese"] = "Swiss";

            return this;
        }

        public override SandwichBuilder AddCondiments()
        {
            sandwich["condiments"] = "Mayo";

            return this;
        }

        public override SandwichBuilder AddMeats()
        {
            sandwich["meat"] = "Turkey";

            return this;
        }

        public override SandwichBuilder AddVeggies()
        {
            sandwich["veggies"] = "Lettuce";

            return this;
        }
    }
}