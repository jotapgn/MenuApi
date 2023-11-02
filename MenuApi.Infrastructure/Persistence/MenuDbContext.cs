using MenuApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MenuApi.Infrastructure.Persistence
{
    public class MenuDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite("DataSource=menub.db;Cache=Shared");

        public DbSet<MenuEntity> Menus { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}