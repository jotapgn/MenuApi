using MenuApi.Domain.Entities;

namespace MenuApi.Infrastructure.Persistence.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(ProductEntity category);
        Task DeleteAsync(int id);
        Task<List<ProductEntity>> GetAllAsync();
        Task<ProductEntity?> GetDetailsById(int id);
        Task SaveAsync();
    }
}