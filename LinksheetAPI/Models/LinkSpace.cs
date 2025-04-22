using System.Text.Json.Serialization;

namespace LinksheetAPI.Models
{
    public class LinkSpace
    {
        public int Id { get; set; }
        public string? LinkPageBackgroundColor { get; set; }
        public string? LinkButtonColor { get; set; }
        public string? LinkButtonFontColor { get; set; }
        public string? LinkPageFontColor { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LinkBorderRadiusType LinkBorderRadius { get; set; } = LinkBorderRadiusType.NotRounded;

        public int UserId { get; set; }
        public User? User { get; set; }

        public enum LinkBorderRadiusType
        {
            NotRounded,
            SlightlyRounded,
            Rounded
        }
    }
}
