namespace StorageMaster.Entities.Vehicles
{
    using Entities.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public abstract class Vehicle
    {
        private int capacity;
        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                capacity = value;
            }
        }

        private readonly List<Product> trunk;
        public IReadOnlyCollection<Product> Trunk
        {
            get
            {
                return this.trunk.AsReadOnly();
            }
        }

        public bool IsFull => this.Trunk.Select(w => w.Weight).Sum() >= this.Capacity;

        public bool IsEmpty => !this.Trunk.Any();

        private Vehicle()
        {
            this.trunk = new List<Product>();
        }

        protected Vehicle(int capacity)
            :this()
        {
            this.Capacity = capacity;
        }

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }

            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }

            Product currentProduct = this.trunk.Last();
            this.trunk.RemoveAt(this.trunk.Count - 1);

            return currentProduct;
        }

    }
}
