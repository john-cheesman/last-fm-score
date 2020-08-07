using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LastFMScore.Models;

namespace LastFMScore.Services
{
    public class StubLastFMService : ILastFMService
    {
        private HttpClient _httpClient;

        public StubLastFMService(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Artist>> GetArtistsForUser(string username)
        {
            var artists = new List<Artist>();

            artists.Add(new Artist()
            {
                Name = "Native Construct",
                Url = "https://last.fm/music/Native+Construct",
                PlayCount = 50
            });

            artists.Add(new Artist()
            {
                Name = "Moon Tooth",
                Url = "https://last.fm/music/Moon+Tooth",
                PlayCount = 30
            });

            return artists;
        }

        public async Task<List<Tag>> GetTagsForArtist(string artist, int limit, string[] exclude = null)
        {
            var tags = new List<Tag>();

            tags.Add(new Tag()
            {
                Name = "Metal",
                Url = new Uri("https://last.fm/tag/metal")
            });

            tags.Add(new Tag()
            {
                Name = "Jazz",
                Url = new Uri("https://last.fm/tag/jazz")
            });

            return tags;
        }
    }
}
