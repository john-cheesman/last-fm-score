using System.Text.Json.Serialization;

namespace LastFMScore.Models
{
    public class Artist
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("playCount")]
        public int PlayCount { get; set; }
    }
}
