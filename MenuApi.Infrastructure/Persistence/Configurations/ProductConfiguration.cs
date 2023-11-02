using MenuApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuApi.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Category)
            .WithOne()
            .HasForeignKey<ProductEntity>(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
