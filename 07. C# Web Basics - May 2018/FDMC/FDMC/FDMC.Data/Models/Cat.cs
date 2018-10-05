namespace FDMC.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Cat
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, 20)]
        public int Age { get; set; }

        [Required]
        public string Breed { get; set; }

        [Required]
        [MinLength(3)]
        public string Url { get; set; }
    }
}
