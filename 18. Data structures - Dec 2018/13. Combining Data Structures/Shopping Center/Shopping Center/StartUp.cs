using Shopping_Center;
using System.Text;

StringBuilder builder = new StringBuilder();
ShoppingCenter shoppingCenter = new ShoppingCenter();

int commandNumber = int.Parse(Console.ReadLine()!);

for (int i = 0; i < commandNumber; i++)
{
    string line = Console.ReadLine()!;

    int firstSpace = line.IndexOf(' ');

    string command = line.Substring(0, firstSpace);
    string[] argms = line.Substring(firstSpace + 1).Split(';');

    switch (command)
    {
        case "AddProduct":
            string name = argms[0];
            double price = double.Parse(argms[1]);
            string producer = argms[2];

            Product product = new Product(name, price, producer);
            shoppingCenter.Add(product);
            builder.AppendLine("Product added");
            break;
        case "DeleteProducts":
            if (argms.Length == 1)
            {
                int count = shoppingCenter.DeleteProductsByProducer(argms[0]);
                if (count == 0)
                {
                    builder.AppendLine("No products found");
                }
                else
                {
                    builder.AppendLine($"{count} products deleted");
                }
            }
            else
            {
                int count = shoppingCenter.DeleteProductsByProducerAndName(argms[0], argms[1]);
                if (count == 0)
                {
                    builder.AppendLine("No products found");
                }
                else
                {
                    builder.AppendLine($"{count} products deleted");
                }
            }
            break;
        case "FindProductsByName":
            List<Product> resultByName = shoppingCenter.FindProductsByName(argms[0]).ToList();

            if (resultByName.Count != 0)
            {
                resultByName.ForEach(x => builder.AppendLine(x.ToString()));
            }
            else
            {
                builder.AppendLine("No products found");
            }
            break;
        case "FindProductsByProducer":
            List<Product> resultByProducer = shoppingCenter.FindProductsByProducer(argms[0]).ToList();

            if (resultByProducer.Count != 0)
            {
                resultByProducer.ForEach(x => builder.AppendLine(x.ToString()));
            }
            else
            {
                builder.AppendLine("No products found");
            }
            break;
        case "FindProductsByPriceRange":
            List<Product> resultByPriceRange = shoppingCenter.FindProductsByPriceRange(
                    double.Parse(argms[0]),
                    double.Parse(argms[1]))
                .OrderBy(x => x)
                .ToList();

            if (resultByPriceRange.Count != 0)
            {
                resultByPriceRange.ForEach(x => builder.AppendLine(x.ToString()));
            }
            else
            {
                builder.AppendLine("No products found");
            }
            break;
        default:
            break;
    }
}

Console.WriteLine(builder
    .ToString()
    .Trim());