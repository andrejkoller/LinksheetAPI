﻿using System.ComponentModel.DataAnnotations;

namespace LinksheetAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(3)]
        public string Username { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        
        public ICollection<Link>? Links { get; set; } = new List<Link>();
        public LinkSpace? LinkSpace { get; set; } = new LinkSpace();
    }
}
