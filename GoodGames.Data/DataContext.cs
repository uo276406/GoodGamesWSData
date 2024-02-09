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

        public DbSet<Statistics> Statistics { get; set; }

    }
}
