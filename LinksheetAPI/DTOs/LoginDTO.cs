using System.ComponentModel.DataAnnotations;

namespace LinksheetAPI.DTOs
{
    public class LoginDTO
    {
        [Required, MinLength(3)]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
