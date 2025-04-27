using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LinksheetAPI.Models
{
    public class LinkSpace
    {
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? LinkPageBackgroundColor { get; set; }
        public string? LinkButtonColor { get; set; }
        public string? LinkButtonFontColor { get; set; }
        public string? LinkPageFontColor { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LinkBorderRadiusType LinkBorderRadius { get; set; } = LinkBorderRadiusType.NotRounded;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LinkBorderStyleType LinkBorderStyle { get; set; } = LinkBorderStyleType.Solid;

        public int UserId { get; set; }
        public User? User { get; set; }

        public enum LinkBorderRadiusType
        {
            NotRounded,
            SlightlyRounded,
            Rounded
        }

        public enum LinkBorderStyleType
        {
            Solid,
            Dashed,
            Dotted
        }
    }
}
