namespace CarDealer
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using CarDealer.Data;
    using CarDealer.Dtos.Export;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<CarDealerProfile>();
            });

            using (var context = new CarDealerContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //string xmlData = File.ReadAllText(@"..\..\..\Datasets\sales.xml");

                Console.WriteLine(GetSalesWithAppliedDiscount(context));
            }
        }

        //19. Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
              .Include(x => x.Car)
              .ThenInclude(x => x.PartCars)
              .ThenInclude(x => x.Part)
              .Include(x => x.Customer)
              .ProjectTo<FullSaleDto>()
              .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(FullSaleDto[]),
                 new XmlRootAttribute("sales"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), sales, namespaces);

            return sb.ToString().TrimEnd();
        }

        //18. Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customersWithSale = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new ExportTotalSalesByCustomer
                {
                    Name = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(z => z.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportTotalSalesByCustomer[]),
                new XmlRootAttribute("customers"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), customersWithSale, namespaces);

            return sb.ToString().TrimEnd();
        }

        //17. Export Cars With Their List Of Parts 
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsListOfParts = context
                  .Cars
                  .Select(c => new ExportCarsWithTheirListOfParts()
                  {
                      Make = c.Make,
                      Model = c.Model,
                      TravelledDistance = c.TravelledDistance,
                      Parts = context.PartCars.Where(s => s.CarId == c.Id).Select(p => new PartDto()
                      {
                          Name = p.Part.Name,
                          Price = p.Part.Price
                      })
                      .OrderByDescending(p => p.Price)
                      .ToArray(),
                  })
                  .OrderByDescending(d => d.TravelledDistance)
                  .ThenBy(m => m.Model)
                  .Take(5)
                  .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsWithTheirListOfParts[]),
               new XmlRootAttribute("cars"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), carsListOfParts, namespaces);

            return sb.ToString().TrimEnd();
        }

        //16. Export Local Suppliers 
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSuppliers
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportLocalSuppliers[]),
                new XmlRootAttribute("suppliers"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), localSuppliers, namespaces);

            return sb.ToString().TrimEnd();
        }

        //15. Export Cars From Make BMW 
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var carsBMW = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new ExportCarsFromMakeBMW
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsFromMakeBMW[]),
               new XmlRootAttribute("cars"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), carsBMW, namespaces);

            return sb.ToString().TrimEnd();
        }

        //14. Export Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Select(c => new ExportCarsWithDistance
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsWithDistance[]),
               new XmlRootAttribute("cars"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        //13. Import Sales 
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSalesDto[]),
               new XmlRootAttribute("Sales"));

            var salesDto = (ImportSalesDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var carsIds = context.Cars.Select(c => c.Id).ToArray();

            var sales = new List<Sale>();

            foreach (var saleDto in salesDto)
            {
                if (!carsIds.Contains(saleDto.CarId))
                {
                    continue;
                }
                var sale = Mapper.Map<Sale>(saleDto);
                sales.Add(sale);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]),
               new XmlRootAttribute("Customers"));

            var customersDto = (ImportCustomerDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var customers = new List<Customer>();

            foreach (var customerDto in customersDto)
            {
                var customer = Mapper.Map<Customer>(customerDto);
                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        //11. Import Cars 
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var carsParsed = XDocument.Parse(inputXml)
                .Root
                .Elements()
                .ToList();

            var cars = new List<Car>();

            var existingPartsIds = context.Parts
                .Select(x => x.Id)
                .ToArray();

            foreach (var x in carsParsed)
            {
                Car currentCar = new Car()
                {
                    Make = x.Element("make").Value,
                    Model = x.Element("model").Value,
                    TravelledDistance = Convert.ToInt64(x.Element("TraveledDistance").Value)
                };

                var partIds = new HashSet<int>();

                foreach (var id in x.Element("parts").Elements())
                {
                    var pid = Convert.ToInt32(id.Attribute("id").Value);
                    partIds.Add(pid);
                }

                foreach (var pid in partIds)
                {
                    PartCar currentPair = new PartCar()
                    {
                        Car = currentCar,
                        PartId = pid
                    };

                    if (existingPartsIds.Contains(pid) == false)
                        continue;

                    currentCar.PartCars.Add(currentPair);
                }

                cars.Add(currentCar);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}";
        }

        //10. Import Parts 
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartsDto[]),
                new XmlRootAttribute("Parts"));

            var partsDto = (ImportPartsDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var parts = new List<Part>();

            var suppliersIds = context.Suppliers.Select(s => s.Id).ToArray();

            foreach (var partDto in partsDto)
            {

                if (!suppliersIds.Contains(partDto.SupplierId))
                {
                    continue;
                }
                var part = Mapper.Map<Part>(partDto);
                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        //09. Import Suppliers 
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSuppliresDto[]),
                new XmlRootAttribute("Suppliers"));

            var suppliersDto = (ImportSuppliresDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var suppliers = new List<Supplier>();

            foreach (var supplierDto in suppliersDto)
            {
                var supplier = Mapper.Map<Supplier>(supplierDto);
                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }
    }
}