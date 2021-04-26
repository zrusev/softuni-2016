namespace Abstract_Factory.Factories.Concrete
{
    using Abstract;
    using Entities.Abstract;
    using Entities.Concrete;

    public class KidCuisineFactory : RecipeFactory
    {
        public override Dessert CreateDessert()
            => new IceCreamSundae();

        public override Sandwich CreateSandwich()
            => new GrilledCheese();
    }
}