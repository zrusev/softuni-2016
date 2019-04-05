namespace CarDealer
{
    using Data;
    using DTO;
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new CarDealerContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //var inputJson = File.ReadAllText(@"..\..\..\Datasets\suppliers.json");

                Console.WriteLine(GetOrderedCustomers(context));
            }
        }

        //19. Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesWithDiscount = context.Sales
                .Select(x => new
                {
                    car = x.Car,
                    customerName = x.Customer.Name,
                    x.Discount,
                    price = x.Car.PartCars.Select(p => p.Part.Price).Sum()

                })
                .Take(10)
                .ToList()
                .Select(x => new
                {
                    car = new
                    {
                        x.car.Make,
                        x.car.Model,
                        x.car.TravelledDistance
                    },
                    x.customerName,
                    Discount = x.Discount.ToString("F2"),
                    price = x.price.ToString("F2"),
                    priceWithDiscount = (x.price - ((x.Discount / 100.0m) * x.price)).ToString("F2")
                })
                .ToArray(); ;


            return JsonConvert.SerializeObject(salesWithDiscount, Formatting.Indented);
        }

        //18. Export Total Sales By Customer 
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var totalSales = context.Customers
              .Where(x => x.Sales.Any())
              .Select(x => new
              {
                  fullName = x.Name,
                  boughtCars = x.Sales.Count,
                  sales = x.Sales.Select(s => new
                  {
                      Price = s.Car.PartCars.Select(pc => pc.Part.Price).Sum(),
                      s.Discount
                  })
                  .ToList()
              })
              .ToList()
              .Select(x => new
              {
                  x.fullName,
                  x.boughtCars,
                  spentMoney = x.sales.Sum(s => s.Price)
              })
              .OrderByDescending(x => x.spentMoney)
              .ThenByDescending(x => x.boughtCars)
              .ToList();

            return JsonConvert.SerializeObject(totalSales, Formatting.Indented);
        }

        //17. Export Cars With Their List Of Parts 
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsListOfParts = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },

                    parts = c.PartCars.Select(p => new
                    {
                        p.Part.Name,
                        Price = p.Part.Price.ToString("F2")
                    })
                        .ToList()
                })
                .ToList();

            return JsonConvert.SerializeObject(carsListOfParts, Formatting.Indented);
        }

        //16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            return JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
        }

        //15. Export Cars From Make Toyota 
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .ToList();

            return JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);
        }

        //14. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    c.IsYoungDriver
                })
                .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        //13. Import Sales 
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson)
                .ToList();

            var youngDrivers = context.Customers
                .Where(c => c.IsYoungDriver)
                .Select(c => c.Id)
                .ToArray();

            foreach (var sale in sales)
            {
                if (youngDrivers.Contains(sale.CustomerId))
                {
                    sale.Discount += 5;
                }
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        //12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson)
                .ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";

        }

        //11. Import Cars 
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsData = JsonConvert.DeserializeObject<PartsCarDto[]>(inputJson)
                .ToList();

            var cars = new List<Car>();
            var partsCar = new List<PartCar>();
            var partsCount = context.Parts.Count();

            foreach (var carData in carsData)
            {
                var car = new Car()
                {
                    Make = carData.Make,
                    Model = carData.Model,
                    TravelledDistance = carData.TravelledDistance
                };

                foreach (var part in carData.PartsId.Distinct())
                {
                    if (part <= partsCount)
                    {
                        partsCar.Add(new PartCar()
                        {
                            Car = car,
                            PartId = part
                        });
                    }
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(partsCar);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        //10. Import Parts 
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var supplierdCount = context.Suppliers.Count();

            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => p.SupplierId < supplierdCount)
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        //09. Import Suppliers 
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var supplires = JsonConvert.DeserializeObject<Supplier[]>(inputJson)
                .ToList();

            context.Suppliers.AddRange(supplires);
            context.SaveChanges();
            return $"Successfully imported {supplires.Count}.";
        }
    }
}