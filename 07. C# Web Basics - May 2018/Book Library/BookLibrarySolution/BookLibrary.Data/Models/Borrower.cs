namespace BookLibrary.Data.Models
{
    using BookLibrary.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Borrower
    {
        public int Id { get; set; }

        [Required]
        [MinLength(Constants.MIN_LENGTH), MaxLength(Constants.MAX_LENGTH)]
        public string Name { get; set; }

        [Required]
        [MinLength(1), MaxLength(255)]
        public string Address { get; set; }

        [Required]
        public ICollection<Trel_BookBorrower> Books { get; set; }
    }
}
