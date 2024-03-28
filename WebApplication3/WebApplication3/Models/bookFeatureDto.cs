using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class bookFeatureDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";
        [Required]
        public int bookPage { get; set; }
        [Required]
        public string Publisher { get; set; } = "";
        [Required]
        public int printingNo { get; set; }
    }
}
