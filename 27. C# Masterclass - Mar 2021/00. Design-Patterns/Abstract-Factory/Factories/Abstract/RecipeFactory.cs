namespace Abstract_Factory.Factories.Abstract
{
    using Entities.Abstract;

    public abstract class RecipeFactory
    {
        public abstract Sandwich CreateSandwich();

        public abstract Dessert CreateDessert();
    }
}