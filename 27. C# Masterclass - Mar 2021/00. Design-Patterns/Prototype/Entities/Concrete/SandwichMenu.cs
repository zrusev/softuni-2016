namespace Prototype.Entities.Concrete
{
    using Entities.Abstract;
    using System.Collections.Generic;
    
    public class SandwichMenu
    {
        private Dictionary<string, SandwichPrototype> sandwiches = new Dictionary<string, SandwichPrototype>();

        public SandwichPrototype this[string name]
        {
            get => this.sandwiches[name];
            set { this.sandwiches.Add(name, value); }
        }
    }
}