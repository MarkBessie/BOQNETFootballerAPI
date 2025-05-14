using BOQNETFootballerAPI.Data;
using BOQNETFootballerAPI.Data.Models;
using BOQNETFootballerAPI.Data.Models.DTO;
using BOQNETFootballerAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BOQNETFootballerAPI.Services
{
    public class FootballerStatsService : IFootballerStats
    {
        private readonly AppDbContext _db;

        public FootballerStatsService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<FootballerMatchStats> CreateFootballerMatchStats(FootballerMatchStats footballerMatchStats)
        {
            try
            {
                await _db.FootballerMatchStats.AddAsync(footballerMatchStats);
                await _db.SaveChangesAsync();
                return footballerMatchStats;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating footballer match stats", ex);
            }
        }

        public async Task<List<FootballerMatchStats>> GetAllFootballerMatchStats(int footballerId)
        {
            try
            {
                return await _db.FootballerMatchStats
                    .Where(f => f.FootballerId == footballerId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving footballer match stats", ex);
            }
        }

        public async Task<FootballerMatchStats> GetFootballerMatchStats(int matchId, int footballerId)
        {
            try
            {
                return await _db.FootballerMatchStats
                    .FirstOrDefaultAsync(f => f.FootballerMatchStatsId == matchId && f.FootballerId == footballerId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving footballer match stats", ex);
            }
        }

        public async Task<MatchStatsSummaryDto?> GetMatchStatsSummary(int footballerId)
        {
            try
            {
                return await _db.FootballerMatchStats
                    .Where(f => f.FootballerId == footballerId)
                    .GroupBy(f => f.FootballerId)
                    .Select(g => new MatchStatsSummaryDto
                    {
                        FootballerId = footballerId,
                        TotalGoals = g.Sum(f => f.GoalsScored),
                        TotalAssists = g.Sum(f => f.Assists),
                        TotalMatches = g.Count(),
                        TotalMinutesPlayed = g.Sum(f => f.MinutesPlayed),
                        AveragePassCompletionPercentage = g.Average(f => f.PassCompletionPercentage)
                    })
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating match stats summary", ex);
            }
        }
    }
}
