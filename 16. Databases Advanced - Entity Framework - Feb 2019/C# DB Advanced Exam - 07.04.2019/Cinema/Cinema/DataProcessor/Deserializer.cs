namespace Cinema.DataProcessor
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using System.Xml.Serialization;
    using System.IO;
    using System.Globalization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesDto = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);
            var movies = new List<Movie>();

            var sb = new StringBuilder();

            foreach (var currentDto in moviesDto)
            {
                if (!IsValid(currentDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                var movie = new Movie
                {
                    Title = currentDto.Title,
                    Genre = Enum.Parse<Genre>(currentDto.Genre),
                    Duration = TimeSpan.Parse(currentDto.Duration),
                    Rating = (double)currentDto.Rating,
                    Director = currentDto.Director
                };

                movies.Add(movie);
                sb.AppendLine($"Successfully imported {movie.Title} with genre {movie.Genre} and rating {movie.Rating:f2}!");
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallsDto = JsonConvert.DeserializeObject<ImportHallDto[]>(jsonString);

            var sb = new StringBuilder();

            foreach (var currentDto in hallsDto)
            {
                if (!IsValid(currentDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = currentDto.Name,
                    Is4Dx = currentDto.Is4Dx,
                    Is3D = currentDto.Is3D
                };

                context.Halls.Add(hall);
                context.SaveChanges();

                int id = hall.Id;

                for (int i = 0; i < currentDto.Seats; i++)
                {
                    var seat = new Seat
                    {
                        HallId = id,
                        Hall = hall
                    };

                    hall.Seats.Add(seat);
                    context.Seats.Add(seat);
                }

                context.SaveChanges();

                bool isNormal = !hall.Is4Dx && !hall.Is3D;
                var end = string.Empty;
                if (hall.Is4Dx == true && hall.Is3D == true)
                {
                    end = "4Dx/3D";
                }
                else if (hall.Is4Dx)
                {
                    end = "4Dx";
                }
                else
                {
                    end = "3D";
                }

                var type = isNormal ? "Normal" : end;
                sb.AppendLine($"Successfully imported {hall.Name}({type}) with {currentDto.Seats} seats!");
            }

            string result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectionsDto[]), new XmlRootAttribute("Projections"));
            var projectionsDto = (ImportProjectionsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var projections = new List<Projection>();

            foreach (var currentDto in projectionsDto)
            {
                if (!IsValid(currentDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = context.Movies.FirstOrDefault(x => x.Id == currentDto.MovieId);
                var hall = context.Halls.FirstOrDefault(x => x.Id == currentDto.HallId);

                if (movie == null || hall == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    MovieId = currentDto.MovieId,
                    Movie = movie,
                    HallId = currentDto.HallId,
                    Hall = hall,
                    DateTime = DateTime.ParseExact(currentDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                projections.Add(projection);
                sb.AppendLine($"Successfully imported projection {projection.Movie.Title} on {projection.DateTime.ToString("MM/dd/yyyy")}!");
            }

            context.Projections.AddRange(projections);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomerTicketDto[]), new XmlRootAttribute("Customers"));
            var customersDto = (ImportCustomerTicketDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var tickets = new List<Ticket>();

            foreach (var currentDto in customersDto)
            {
                if (!IsValid(currentDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = currentDto.FirstName,
                    LastName = currentDto.LastName,
                    Age = currentDto.Age,
                    Balance = currentDto.Balance
                };

                context.Customers.Add(customer);
                context.SaveChanges();

                foreach (var currentTicket in currentDto.Tickets)
                {
                    var projection = context.Projections.FirstOrDefault(i => i.Id == currentTicket.ProjectionId);

                    var ticket = new Ticket
                    {
                        ProjectionId = currentTicket.ProjectionId,
                        Projection = projection,
                        Price = currentTicket.Price,
                        CustomerId = customer.Id,
                        Customer = customer
                    };

                    tickets.Add(ticket);
                }

                sb.AppendLine($"Successfully imported customer {customer.FirstName} {customer.LastName} with bought tickets: {currentDto.Tickets.Count()}!");
            }

            context.Tickets.AddRange(tickets);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();
            return result;
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }
    }
}
