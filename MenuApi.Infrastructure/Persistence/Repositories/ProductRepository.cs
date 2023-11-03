using MenuApi.Domain.Entities;
using MenuApi.Infrastructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MenuApi.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MenuDbContext _context;
        public ProductRepository(MenuDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProductEntity>> GetAllAsync()
        {
            return await _context.Products
                .ToListAsync();
        }
        public async Task<ProductEntity?> GetDetailsById(int id)
        {
            return await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id) ?? null;
        }
        public async Task AddAsync(ProductEntity product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var product = await GetDetailsById(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
