using MenuApi.Domain.Entities;
using MenuApi.Infrastructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MenuApi.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MenuDbContext _context;
        public CategoryRepository(MenuDbContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryEntity>> GetAllAsync()
        {
            return await _context.Categories
                .ToListAsync();
        }
        public async Task<CategoryEntity?> GetDetailsById(int id)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id) ?? null;
        }
        public async Task AddAsync(CategoryEntity category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var category = await GetDetailsById(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
