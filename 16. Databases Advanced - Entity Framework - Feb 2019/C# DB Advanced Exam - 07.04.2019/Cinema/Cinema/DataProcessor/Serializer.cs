namespace Cinema.DataProcessor
{
    using Data;
    using ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                .Where(r => r.Rating >= rating)
                .Where(sld => sld.Projections.SelectMany(t => t.Tickets).Any())
                .Select(m => new {
                    MovieName = m.Title,
                    Rating = m.Rating,
                    TotalIncomes = m.Projections.SelectMany(p => p.Tickets).Sum(s => s.Price),
                    Customers = m.Projections.SelectMany(p => p.Tickets).Select(s => new {
                        FirstName = s.Customer.FirstName,
                        LastName = s.Customer.LastName,
                        Balance = s.Customer.Balance.ToString("F2")
                    })
                    .OrderByDescending(b => b.Balance)
                    .ThenBy(f => f.FirstName)
                    .ThenBy(l => l.LastName)
                    .ToList()
                })
                .OrderByDescending(r => r.Rating)
                .ThenByDescending(i => i.TotalIncomes)
                .ToList();

            var newList = movies.Select(m => new
            {
                MovieName = m.MovieName,
                Rating = m.Rating.ToString("F2"),
                TotalIncomes = m.TotalIncomes.ToString("F2"),
                Customers = m.Customers.Select(c => new
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Balance = c.Balance
                })
                    .ToList()
            })
                .Take(10)
                .ToList();

            var jsonResult = JsonConvert.SerializeObject(newList, Newtonsoft.Json.Formatting.Indented);

            return jsonResult;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context
                .Customers
                .Where(a => a.Age >= age)
                .Select(c => new {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    SpentMoney = c.Tickets.Sum(p => p.Price),
                    SpentTime = c.Tickets.Sum(tk => tk.Projection.Movie.Duration.Ticks)
                })
                .OrderByDescending(m => m.SpentMoney)
                .ToArray();

            var newList = customers.Select(c => new ExportCustomerDto
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                SpentMoney = c.SpentMoney.ToString("F2"),
                SpentTime = new TimeSpan(c.SpentTime).ToString(@"hh\:mm\:ss")
            })
            .Take(10)
            .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCustomerDto[]), new XmlRootAttribute("Customers"));
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty,
            });

            var sb = new StringBuilder();
            xmlSerializer.Serialize(new StringWriter(sb), newList, namespaces);

            var result = sb.ToString().TrimEnd();        
            return result;
        }
    }
}