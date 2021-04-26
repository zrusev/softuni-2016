namespace Factory_Method.Entities.Abstract
{
    using System.Collections.Generic;

    public abstract class Sandwich
    {
        private List<Ingredient> ingridients = new List<Ingredient>();

        public Sandwich()
            => this.CreateIngredients();

        public abstract void CreateIngredients();

        public List<Ingredient> Ingredients => this.ingridients;

    public int IngredientsCount => this.ingridients.Count;
    }
}