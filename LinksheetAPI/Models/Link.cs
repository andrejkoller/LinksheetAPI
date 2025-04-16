namespace LinksheetAPI.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
