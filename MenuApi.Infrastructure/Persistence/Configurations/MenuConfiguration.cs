using MenuApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuApi.Infrastructure.Persistence.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<MenuEntity>
    {
        public void Configure(EntityTypeBuilder<MenuEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(m => m.Products)
            .WithOne(x => x.Menu)
            .HasForeignKey(x => x.MenuId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
