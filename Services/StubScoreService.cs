using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastFMScore.Models;

namespace LastFMScore.Services
{
    public class StubScoreService : IScoreService
    {
        public StubScoreService(ILastFMService lastFMService)
        {
        }

        public async Task<int> GetScore(List<Artist> artists)
        {
            return 100;
        }
    }
}
