using System.Collections.Generic;
using System.Threading.Tasks;
using LastFMScore.Models;

namespace LastFMScore.Services
{
    public interface IScoreService
    {
        public Task<int> GetScore(List<Artist> artists);
    }
}
