namespace SoftUni.WebServer.Web.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    public class DeleteProductModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ProductType { get; set; }
    }
}
