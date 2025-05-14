using BOQNETFootballerAPI.Data.Models;
using BOQNETFootballerAPI.Data.Models.DTO;

namespace BOQNETFootballerAPI.Repositories
{
    public interface IFootballerStats
    {
        Task<FootballerMatchStats> CreateFootballerMatchStats(FootballerMatchStats footballerMatchStats);
        Task<FootballerMatchStats> GetFootballerMatchStats(int matchId, int footballerId);
        Task<List<FootballerMatchStats>> GetAllFootballerMatchStats(int footballerId);
        Task<MatchStatsSummaryDto?> GetMatchStatsSummary(int footballerId);
    }
}
