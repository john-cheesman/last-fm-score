using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using LastFMScore.Models;

namespace LastFMScore.Services
{
    public class LastFMService : ILastFMService
    {
        private HttpClient _httpClient;
        private string _apiKey;

        public LastFMService(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
        }

        public async Task<List<Artist>> GetArtistsForUser(string username)
        {
            Console.WriteLine($"GetArtists for {username}");
            var response = await _httpClient.GetAsync($"?method=user.gettopartists&user={username}&api_key={_apiKey}&format=json&period=overall&limit=100");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = response.Content.ReadAsStringAsync().Result;

                return JsonSerializer.Deserialize<TopArtistsResponse>(content).TopArtists.Artist;
            }
            else
            {
                throw new Exception($"Unable to get artists for user: {username}");
            }
        }

        public async Task<List<Tag>> GetTagsForArtist(string artist, int limit, string[] exclude = null)
        {
            Console.WriteLine($"Get top {limit} tags for {artist}");
            var response = await _httpClient.GetAsync($"?method=artist.gettoptags&artist={artist}&api_key={_apiKey}&format=json");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                List<Tag> tags = JsonSerializer.Deserialize<TopTagsResponse>(content).TopTags.Tag;

                if (exclude != null)
                {
                    for(int i = 0; i < tags.Count(); i++)
                    {
                        foreach(string excluded in exclude)
                        {
                            if (string.Equals(tags[i].Name, excluded, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine($"Removing {tags[i].Name}");
                                tags.RemoveAt(i);
                            }
                        }
                    }
                }

                return tags.Take(limit).ToList();
            }
            else
            {
                throw new Exception($"Unable to get tags for artist: {artist}");
            }
        }
    }
}
