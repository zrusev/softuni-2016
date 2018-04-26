namespace StorageMaster.Entities.Products
{
    using System;
    public abstract class Product
    {
        private double price;
        public double Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }

                this.price = value;
            }
        }

        private double weight;
        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                this.weight = value;
            }
        }

        protected Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }
    }
}
