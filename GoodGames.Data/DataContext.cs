using Microsoft.EntityFrameworkCore;
using GoodGames.Data.Model;

namespace GoodGames.Data
{
    public class DataContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=data/database.db");
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }

    }
}
