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

                throw new Exception("There was an error adding the footballer:",ex);
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

                throw new Exception("There was an error retrieving the footballers:", ex);
            }
           
        }

        public async Task<Footballer> GetFootballerByIdAsync(int id)
        {
            try
            {
                return await _db.Footballer.Where(f => f.Id == id)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the footballer:", ex);
            }
            
        }

        public Task<Footballer> UpdateFootballerAsync(Footballer footballer)
        {
            try
            {
                _db.Footballer.Update(footballer);
                _db.SaveChangesAsync();
                return Task.FromResult(footballer);
            }
            catch (Exception ex)
            {

                throw new Exception("There was an error updating the footballer:", ex);
            }
            
        }
    }
}
