namespace Prototype.Entities.Concrete
{
    using Abstract;
    using System.Text;

    public class Sandwich : SandwichPrototype
    {
        private string bread;
        private string meat;

        public Sandwich(string bread, string meat)
        {
            this.bread = bread;
            this.meat = meat;
        }

        public override SandwichPrototype Clone()
        {
            string ingredientList = this.GetIngredientList();
            
            return MemberwiseClone() as SandwichPrototype;
        }

        private string GetIngredientList() 
            => new StringBuilder()
                .AppendLine(this.bread)
                .AppendLine(this.meat)
                .ToString();
    }
}