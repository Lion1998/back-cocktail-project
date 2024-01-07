using System.ComponentModel.DataAnnotations;

namespace cocktail_project.Models
{
    public class Login
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter a email!")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please enter a password!")]
        public string? Password { get; set; }

        public string Type { get; set; }

    }
}
