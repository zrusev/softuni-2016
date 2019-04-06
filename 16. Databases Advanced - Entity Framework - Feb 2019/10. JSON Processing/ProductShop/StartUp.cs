namespace ProductShop
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using ProductShop.Data;
    using ProductShop.Dtos.Export;
    using ProductShop.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var dataJSON = File.ReadAllText(@"..\..\..\Datasets\categories-products.json");

            Console.WriteLine(GetUsersWithProducts(context));
        }

        //08. Export Users and Products 
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var filteredUsers = context
               .Users
               .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
               .OrderByDescending(u => u.ProductsSold.Count(ps => ps.Buyer != null))
               .Select(u => new
               {
                   FirstName = u.FirstName,
                   LastName = u.LastName,
                   Age = u.Age,
                   SoldProducts = new
                   {
                       Count = u.ProductsSold
                       .Count(ps => ps.Buyer != null),
                       Products = u.ProductsSold
                       .Where(ps => ps.Buyer != null)
                       .Select(ps => new
                       {
                           Name = ps.Name,
                           Price = ps.Price
                       })
                       .ToArray()
                   }

               })
               .ToArray();

            var result = new
            {
                UsersCount = filteredUsers.Length,
                Users = filteredUsers
            };

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var json = JsonConvert.SerializeObject(
                result,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = contractResolver,
                    NullValueHandling = NullValueHandling.Ignore
                });

            return json;
        }

        //07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var values = context.Categories
                     .Select(x => new
                     {
                         x.Name,
                         Prices = x.CategoryProducts
                            .Select(cp => cp.Product.Price)
                            .ToList()
                     })
                     .ToList()
                     .Select(x => new
                     {
                         category = x.Name,
                         productsCount = x.Prices.Count,
                         averagePrice = (x.Prices.Sum() / x.Prices.Count).ToString("F2"),
                         totalRevenue = (x.Prices.Sum()).ToString("F2")
                     })
                     .OrderByDescending(x => x.productsCount)
                     .ToList();

            return JsonConvert.SerializeObject(values, Formatting.Indented);
        }

        //06. Export Sold Products 
        public static string GetSoldProducts(ProductShopContext context)
        {
            var filteredUsers = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                    .Where(ps => ps.Buyer != null)
                    .Select(ps => new
                    {
                        Name = ps.Name,
                        Price = ps.Price,
                        BuyerFirstName = ps.Buyer.FirstName,
                        BuyerLastName = ps.Buyer.LastName
                    })
                    .ToArray()
                })
                .ToArray();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var json = JsonConvert.SerializeObject(
                filteredUsers,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = contractResolver
                });

            return json;
        }

        //05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                 .Where(p => p.Price >= 500 && p.Price <= 1000)
                 .Select(p => new ProductDto
                 {
                     Name = p.Name,
                     Price = p.Price,
                     Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"

                 })
                 .OrderBy(p => p.Price)
                 .ToList();

            var json = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);
            return json;
        }

        //04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson)
                .ToList();

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count}";
        }

        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(c => !string.IsNullOrEmpty(c.Name))
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported { categories.Count}";
        }

        //02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson)
                .Where(p => !string.IsNullOrEmpty(p.Name) && p.Name.Length >= 3)
                .ToList();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //01. Import Users 
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);
            var validUsers = new List<User>();

            foreach (var user in users)
            {
                if (user.LastName == null || user.LastName.Length < 3)
                {
                    continue;
                }

                validUsers.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }
    }
}