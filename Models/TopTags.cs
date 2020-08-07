using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LastFMScore.Models
{
    public class TopTags
    {
        [JsonPropertyName("tag")]
        public List<Tag> Tag { get; set; }

        [JsonPropertyName("@attr")]
        public ArtistAttributes Attributes { get; set; }
    }
}
