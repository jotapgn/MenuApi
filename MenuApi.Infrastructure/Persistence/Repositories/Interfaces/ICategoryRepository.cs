using MenuApi.Domain.Entities;

namespace MenuApi.Infrastructure.Persistence.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task AddAsync(CategoryEntity category);
        Task DeleteAsync(int id);
        Task<List<CategoryEntity>> GetAllAsync();
        Task<CategoryEntity?> GetDetailsById(int id);
        Task SaveAsync();
    }
}