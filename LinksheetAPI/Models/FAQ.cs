using System.ComponentModel.DataAnnotations;

namespace LinksheetAPI.Models
{
    public class FAQ
    {
        [Key]
        public int Id { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
    }
}
