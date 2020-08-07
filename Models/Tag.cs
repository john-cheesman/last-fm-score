using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace LastFMScore.Models
{
    public class Tag
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public Uri Url { get; set; }
    }

    public class TagComparer : IEqualityComparer<Tag>
    {
        public bool Equals(Tag x, Tag y)
        {
            if (string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        public int GetHashCode(Tag obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
