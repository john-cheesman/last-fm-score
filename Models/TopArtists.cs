using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LastFMScore.Models
{
    public class TopArtists
    {
        [JsonPropertyName("artist")]
        public List<Artist> Artist { get; set; }

        [JsonPropertyName("@attr")]
        public UserAttributes Attributes { get; set; }
    }
}
