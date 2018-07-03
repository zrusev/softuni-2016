namespace SoftUni.WebServer.Models
{
    using System;

    public class ProductOrder
    {
        public int Id { get; set; }

        public int IdProduct { get; set; }

        public Product Product { get; set; }

        public Guid IdOrder { get; set; }

        public Order Order { get; set; } 
    }
}
