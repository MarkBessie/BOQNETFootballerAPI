using BOQNETFootballerAPI.Data.Models;

namespace BOQNETFootballerAPI.Repositories
{
    public interface IFootballer
    {
        Task<List<Footballer>> GetAllFootballersAsync();
        Task<Footballer> GetFootballerByIdAsync(int id);
        Task<Footballer> AddFootballerAsync(Footballer footballer);
        Task<Footballer> UpdateFootballerAsync(Footballer footballer);

    }
}
