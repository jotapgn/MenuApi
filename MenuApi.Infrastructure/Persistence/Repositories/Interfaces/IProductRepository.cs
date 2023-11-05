using MenuApi.Domain.Entities;

namespace MenuApi.Infrastructure.Persistence.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(ProductEntity category);
        Task DeleteAsync(int id);
        Task<List<ProductEntity>> GetAllByMenuAsync(int id);
        Task<List<ProductEntity>> GetAllByCategoryAsync(int id);
        Task<ProductEntity?> GetDetailsById(int id);
        Task SaveAsync();
    }
}