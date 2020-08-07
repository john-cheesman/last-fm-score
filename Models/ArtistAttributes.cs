using System.Text.Json.Serialization;

namespace LastFMScore.Models
{
    public class ArtistAttributes
    {
        [JsonPropertyName("artist")]
        public string Artist { get; set; }
    }
}
