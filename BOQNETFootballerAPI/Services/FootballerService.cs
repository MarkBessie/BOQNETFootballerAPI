using BOQNETFootballerAPI.Data;
using BOQNETFootballerAPI.Data.Models;
using BOQNETFootballerAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BOQNETFootballerAPI.Services
{
    public class FootballerService : IFootballer
    {
        private readonly AppDbContext _db;

        public FootballerService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Footballer> AddFootballerAsync(Footballer footballer)
        {
            try
            {
                _db.Footballer.Add(footballer);
                await _db.SaveChangesAsync();
                return footballer;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding footballer", ex);
            }
        }

        public async Task<List<Footballer>> GetAllFootballersAsync()
        {
            try
            {
                return await _db.Footballer.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving footballers", ex);
            }
        }

        public async Task<Footballer> GetFootballerByIdAsync(int id)
        {
            try
            {
                return await _db.Footballer.FirstOrDefaultAsync(f => f.FootballerId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving footballer", ex);
            }
        }

        public async Task<Footballer> UpdateFootballerAsync(Footballer footballer)
        {
            try
            {
                _db.Footballer.Update(footballer);
                await _db.SaveChangesAsync();
                return footballer;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating footballer", ex);
            }
        }
    }
}
