namespace SoftUni.WebServer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        public ProductType ProductType { get; set; }

        public ICollection<ProductOrder> OrderNavigation { get; set; }
    }
}
