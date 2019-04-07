namespace Cinema.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Projection
    {
        public Projection()
        {
            this.Tickets = new List<Ticket>();
        }

        public int Id { get; set; }

        public int MovieId { get; set; }

        [Required]
        public Movie Movie { get; set; }

        public int HallId { get; set; }

        [Required]
        public Hall Hall { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}