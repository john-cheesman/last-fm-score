using System.Text.Json.Serialization;

namespace LastFMScore.Models
{
    public class TopArtistsResponse
    {
        [JsonPropertyName("topartists")]
        public TopArtists TopArtists { get; set; }
    }
}
