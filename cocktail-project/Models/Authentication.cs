using System.ComponentModel.DataAnnotations;

namespace cocktail_project.Models
{
    public class Authentication
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Type { get; set; }
    }
}
