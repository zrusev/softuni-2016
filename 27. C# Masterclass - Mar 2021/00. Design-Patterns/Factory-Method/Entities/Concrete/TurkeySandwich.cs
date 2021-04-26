using System.Linq;
namespace Factory_Method.Entities.Concrete
{
    using Entities.Abstract;

    public class TurkeySandwich : Sandwich
    {
        public override void CreateIngredients()
        {
            this.Ingredients.Add(new Bread());
            this.Ingredients.Add(new Mayonnaise());
        }
    }
}