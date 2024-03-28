using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class bookPrice
    {
        public int Id { get; set; }

        
        public string Name { get; set; } = "";
        
        public int Stock { get; set; }
        
        public int Price { get; set; }
    }
}
