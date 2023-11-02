using Microsoft.EntityFrameworkCore;

namespace MenuApi.Infrastructure.Persistence
{
    public class MenuDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseSqlite("DataSource=menuDb.db;Cache=Shared");
    }
}
