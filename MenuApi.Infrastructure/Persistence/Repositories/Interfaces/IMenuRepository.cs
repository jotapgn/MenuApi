using MenuApi.Domain.Entities;

namespace MenuApi.Infrastructure.Persistence.Repositories.Interfaces
{
    public interface IMenuRepository
    {
        Task AddAsync(MenuEntity menu);
        Task<List<MenuEntity>> GetAllAsync();
        Task<MenuEntity?> GetDetailsById(int id);
        Task SaveAsync();
        Task<MenuEntity?> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}