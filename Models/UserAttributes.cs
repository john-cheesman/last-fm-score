using System.Text.Json.Serialization;

namespace LastFMScore.Models
{
    public class UserAttributes
    {
        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("Page")]
        public int Page { get; set; }
    }
}
