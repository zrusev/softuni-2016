namespace BookLibrary.Data.Models
{
    using BookLibrary.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Author
    {
        public int Id { get; set; }

        [Required(ErrorMessage = Constants.ERROR_MESSAGE_REQUIRED)]
        [MinLength(Constants.MIN_LENGTH), MaxLength(Constants.MAX_LENGTH)]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
