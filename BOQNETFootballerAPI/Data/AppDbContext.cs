using Microsoft.EntityFrameworkCore;

namespace BOQNETFootballerAPI.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
    }
}
