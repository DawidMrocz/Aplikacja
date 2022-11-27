using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Xml.Linq;

namespace UserMicroservice.Entities
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "You must provide a Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must provide a password")]
        public string PasswordHash { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "You must provide a Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must provide a CCtr")]
        public string CCtr { get; set; }

        [Required(ErrorMessage = "You must provide a ActTyp")]
        public string ActTyp { get; set; }
        public string Role { get; set; }
        public string? Photo { get; set; }
    }
}
