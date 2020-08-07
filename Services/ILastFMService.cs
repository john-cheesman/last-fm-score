using System.Collections.Generic;
using System.Threading.Tasks;
using LastFMScore.Models;

namespace LastFMScore.Services
{
    public interface ILastFMService
    {
        public Task<List<Artist>> GetArtistsForUser(string username);

        public Task<List<Tag>> GetTagsForArtist(string artist, int limit, string[] excluded = null);
    }
}
