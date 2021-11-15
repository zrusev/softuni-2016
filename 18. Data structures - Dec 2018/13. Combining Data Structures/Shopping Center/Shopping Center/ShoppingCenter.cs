using Wintellect.PowerCollections;

namespace Shopping_Center
{
    public class ShoppingCenter
    {
        private Dictionary<string, Bag<Product>> byProducer;
        private Dictionary<string, Bag<Product>> byName;
        private OrderedBag<Product> byPrice;

        public ShoppingCenter()
        {
            this.byProducer = new Dictionary<string, Bag<Product>>();
            this.byName = new Dictionary<string, Bag<Product>>();
            this.byPrice = new OrderedBag<Product>((x, y) => x.Price.CompareTo(y.Price));
        }

        public void Add(Product product)
        {
            if (!this.byProducer.ContainsKey(product.Producer))
            {
                this.byProducer[product.Producer] = new Bag<Product>();
            }

            this.byProducer[product.Producer].Add(product);

            if (!this.byName.ContainsKey(product.Name))
            {
                this.byName[product.Name] = new Bag<Product>();
            }

            this.byName[product.Name].Add(product);
            this.byPrice.Add(product);
        }

        public int DeleteProductsByProducer(string producer)
        {
            if (!this.byProducer.ContainsKey(producer))
            {
                return 0;
            }

            IEnumerable<Product> productsToRemove = this.byProducer[producer];

            int count = 0;
            foreach (var product in productsToRemove)
            {
                string name = product.Name;
                this.byName[name].Remove(product);
                this.byPrice.Remove(product);
                
                count++;
            }

            this.byProducer.Remove(producer);
            return count;
        }

        public int DeleteProductsByProducerAndName(string productName, string producer)
        {
            if (!this.byProducer.ContainsKey(producer))
            {
                return 0;
            }

            IEnumerable<Product> productsToRemove = this.byProducer[producer]
                .Where(x => x.Name == productName)
                .ToList();

            int count = 0;
            foreach (var product in productsToRemove)
            {
                string name = product.Name;
                this.byName[name].Remove(product);
                this.byPrice.Remove(product);
                count++;
            }

            return count;
        }

        public IEnumerable<Product> FindProductsByName(string name)
        {
            if (!this.byName.ContainsKey(name))
            {
                return Enumerable.Empty<Product>();
            }

            return this.byName[name].OrderBy(x => x);
        }
        public IEnumerable<Product> FindProductsByProducer(string producer)
        {
            if (!this.byProducer.ContainsKey(producer))
            {
                return Enumerable.Empty<Product>();
            }

            return this.byProducer[producer].OrderBy(x => x);
        }
        public IEnumerable<Product> FindProductsByPriceRange(double low, double high)
        {
            return this.byPrice
                .Range(new Product(string.Empty, low, string.Empty),
                    true,
                    new Product(string.Empty, high, string.Empty),
                    true)
                .OrderBy(x => x); 
        }
    }
}