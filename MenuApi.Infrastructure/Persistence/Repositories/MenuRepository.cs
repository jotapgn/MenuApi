using MenuApi.Domain.Entities;
using MenuApi.Infrastructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MenuApi.Infrastructure.Persistence.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly MenuDbContext _context;
        public MenuRepository(MenuDbContext context)
        {
            _context = context;
        }
        public async Task<List<MenuEntity>> GetAllAsync()
        {
            return await _context.Menus
                .ToListAsync();
        }
        public async Task<MenuEntity?> GetDetailsById(int id)
        {
            return await _context.Menus
                .Include(p => p.Products)
                .FirstOrDefaultAsync(m => m.Id == id) ?? null;
        }
        public async Task AddAsync(MenuEntity menu)
        {
            await _context.Menus.AddAsync(menu);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var menu = await GetByIdAsync(id);
            if (menu != null)
            {
                _context.Menus.Remove(menu);
                await _context.SaveChangesAsync();
            }      
        }
        public async Task<MenuEntity?> GetByIdAsync(int id)
        {
            return await _context.Menus.SingleOrDefaultAsync(m => m.Id == id);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
