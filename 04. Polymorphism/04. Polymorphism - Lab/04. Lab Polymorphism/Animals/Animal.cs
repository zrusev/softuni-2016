
    using System;

public abstract class Animal
    {
        private string name;
        private string favouriteFood;

        public string FavouriteFood
        {
            get { return this.favouriteFood; }
            protected set { this.favouriteFood = value; }
        }

        public string Name
        {
            get { return this.name; }
            protected set { this.name = value; }
        }

        public virtual string ExplainMyself()
        {
            return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";
        }


    }
