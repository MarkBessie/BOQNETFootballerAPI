using BOQNETFootballerAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BOQNETFootballerAPI.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }       
        public DbSet<Footballer> Footballer { get; set; }
    }
}
