namespace BookLibrary.Data.Models
{
    using BookLibrary.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = Constants.ERROR_MESSAGE_REQUIRED)]
        [MinLength(Constants.MIN_LENGTH), MaxLength(Constants.MAX_LENGTH)]        
        public string Title { get; set; }

        [Required(ErrorMessage = Constants.ERROR_MESSAGE_REQUIRED)]
        [MinLength(Constants.MIN_LENGTH), MaxLength(Constants.MAX_LENGTH)]
        [Display(Name = "Description")]
        public string ShortDescription { get; set; }
        
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image Url")]
        public string CoverImage { get; set; }

        [Required(ErrorMessage = Constants.ERROR_MESSAGE_REQUIRED)]
        public Author Authors { get; set; }

        public ICollection<Trel_BookBorrower> Borrower { get; set; }
    }
}
