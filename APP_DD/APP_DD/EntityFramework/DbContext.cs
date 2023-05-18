using Microsoft.EntityFrameworkCore;
using static APP_DD.Entities;

namespace APP_DD.Entity_Framework
{

    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<FavoriteCars> FavoriteCars { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            _ = Database.EnsureCreated();
        }
    }
}
