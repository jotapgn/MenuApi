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
        public async Task<List<ProductEntity>> GetAllByMenuAsync(int id)
        {
            return await _context.Products.Where(p => p.MenuId == id)
                .Include(p => p.Menu)
                .Include(p => p.Category)
                .ToListAsync();
        }
        public async Task<List<ProductEntity>> GetAllByCategoryAsync(int id)
        {
            return await _context.Products.Where(p => p.CategoryId == id)
                .Include(p => p.Menu)
                .Include(p => p.Category)
                .ToListAsync();
        }
        public async Task<ProductEntity?> GetDetailsById(int id)
        {
            return await _context.Products
                .Include(p => p.Menu)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id) ?? null;
        }
        public async Task AddAsync(ProductEntity product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            await _context.Products.Where(p => p.Id == id).ExecuteDeleteAsync();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
