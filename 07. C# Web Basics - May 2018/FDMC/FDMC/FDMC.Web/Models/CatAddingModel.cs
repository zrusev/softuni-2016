namespace FDMC.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    public class CatAddingModel
    {
        private const string EmptyField = "Field can not be empty";
        private const string WrongRegex = "Regex mismatch";
        private const string WrongRange = "Age should be between 1 and 20";
        private const string MinimalLength = "The length should be above 3 symbols";
        
        [Required(ErrorMessage = EmptyField)]
        public string Name { get; set; }

        [Required(ErrorMessage = EmptyField)]
        [Range(1, 20, ErrorMessage = WrongRange)]
        public int? Age { get; set; }

        [Required(ErrorMessage = EmptyField)]
        public string Breed { get; set; }

        [Required(ErrorMessage = EmptyField)]
        [MinLength(3, ErrorMessage = MinimalLength)]
        [RegularExpression(@"((?:https?\:\/\/|www\.)(?:[-a-z0-9]+\.)*[-a-z0-9]+.*)", ErrorMessage = WrongRegex)]
        //https://forums.asp.net/t/1761988.aspx?Regular+expression+for+Validating+URL+with+or+without+http
        public string Url { get; set; }
    }
}
