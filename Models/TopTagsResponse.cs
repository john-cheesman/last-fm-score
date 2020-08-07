using System.Text.Json.Serialization;

namespace LastFMScore.Models
{
   public class TopTagsResponse
   {
        [JsonPropertyName("toptags")]
        public TopTags TopTags { get; set; }
   }
}
