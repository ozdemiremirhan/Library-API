using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class bookFeature
    {
        
        public int Id { get; set; }

        public string Name { get; set; } = "";
        
        public int bookPage { get; set; }
        
        public string Publisher { get; set; } = "";

        public int printingNo { get; set; }
    }
}
