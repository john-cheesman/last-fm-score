using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LastFMScore.Models;

namespace LastFMScore.Services
{
    public class ScoreService : IScoreService
    {
        private readonly ILastFMService _lastFMService;
        private readonly string[] _excludedTags;

        public ScoreService(ILastFMService lastFMService)
        {
            _lastFMService = lastFMService;
            _excludedTags = new string[]
            {
                "seen live"
            };
        }

        public async Task<int> GetScore(List<Artist> artists)
        {
            try
            {
                Console.WriteLine("Get score");
                List<Tag> allTags = new List<Tag>();
                var tasks = artists.Select(artist => _lastFMService.GetTagsForArtist(artist.Name, 3, _excludedTags));
                var tags = await Task.WhenAll(tasks);

                foreach (List<Tag> tag in tags)
                {
                    allTags = allTags.Union(tag, new TagComparer()).ToList();
                }

                return allTags.Count();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting score: {ex.ToString()}");
                return -1;
            }
        }
    }
}
