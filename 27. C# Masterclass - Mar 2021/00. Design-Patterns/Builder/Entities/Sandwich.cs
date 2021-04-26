namespace Builder.Entities
{
    using System.Collections.Generic;
    public class Sandwich
    {
        private string type;
        private Dictionary<string, string> ingridients = new Dictionary<string, string>();

        public Sandwich(string type)
            => this.type = type;

        public string this[string key]
        {
            get => this.ingridients[key];
            set { this.ingridients[key] = value; }
        }

        public void Show ()
        {
            System.Console.WriteLine($"Sandwich type: {this.type}");
        }
    }
}