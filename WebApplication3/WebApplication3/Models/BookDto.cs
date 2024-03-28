using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class BookDto
    {
        
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public string Author { get; set; } = "";
        [Required]
        public string Theme { get; set; } = "";

    }
}
