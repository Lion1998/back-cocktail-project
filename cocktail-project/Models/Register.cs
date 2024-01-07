
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Numerics;

namespace cocktail_project.Models
{
    public class Register
    {
            public int ID { get; set; }
        [Required(ErrorMessage = "Please enter a first name!")]
        [MaxLength(50, ErrorMessage = "You can use up to 50 characters")]
        [MinLength(2, ErrorMessage = "Please use a minimum of 2 characters")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a last name!")]
        [MaxLength(50, ErrorMessage = "You can use up to 50 characters")]
        [MinLength(2, ErrorMessage = "Please use a minimum of 2 characters")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Please enter a email!")]
        [MaxLength(50, ErrorMessage = "You can use up to 50 characters")]
            public string? Email { get; set; }
        [Required(ErrorMessage = "Please enter a phone!")]
        [MaxLength(13, ErrorMessage = "You can use up to 13 characters")]
        [MinLength(10,ErrorMessage = "Please use a minimum of 10 characters")]
            public string? Phone { get; set; }
        [Required(ErrorMessage = "Please enter a password!")]
        [MaxLength(50, ErrorMessage = "You can use up to 50 characters")]
        [MinLength(5, ErrorMessage = "Please use a minimum of 5 characters")]
            public string? Password { get; set; }
            public string? BD { get; set; }
            public string? Type { get; set; }
        }
}

