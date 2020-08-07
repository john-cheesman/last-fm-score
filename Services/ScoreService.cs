using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
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
            Console.WriteLine("Get score");
            List<Tag> allTags = new List<Tag>();

            foreach (Artist artist in artists)
            {
                List<Tag> tags = await _lastFMService.GetTagsForArtist(artist.Name, 3, _excludedTags);

                allTags = allTags.Union(tags, new TagComparer()).ToList();
            }

            return allTags.Count();
        }
    }
}
