namespace Abstract_Factory.Factories.Concrete
{
    using Abstract;
    using Entities.Abstract;
    using Entities.Concrete;

    public class AdultCuisineFactory : RecipeFactory
    {
        public override Sandwich CreateSandwich()
            => new BLT();

        public override Dessert CreateDessert()
            => new CremeBrule();
    }
}