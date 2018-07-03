namespace SoftUni.WebServer.Models
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Username { get; set; }

        [Required]
        [MinLength(3)]
        public string PasswordHash { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Role Role { get; set; }
    }
}
