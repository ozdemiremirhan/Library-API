using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class bookPriceDto
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";
        [Required]
        public int Stock { get; set; }
        [Required]
        public int Price { get; set; }

    }
}
