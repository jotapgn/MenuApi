using MediatR;
using MenuApi.Application.ViewModels;
using MenuApi.Infrastructure.Persistence.Repositories.Interfaces;

namespace MenuApi.Application.Queries.GetAllProductsByCategory
{
    public class GetAllProductsByCategoryQueryHandler : IRequestHandler<GetAllProductsByCategoryQuery, List<ProductViewModel>>
    {
        private readonly IProductRepository _productRepository;
        public GetAllProductsByCategoryQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductViewModel>> Handle(GetAllProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllByCategoryAsync(request.IdCategory);

            var productsByCategory = products
                                                        .Select(p =>
                                                            new ProductViewModel(p.Id,
                                                                p.Name,
                                                                p.Description,
                                                                p.Price,
                                                                p.MenuId,
                                                                p.Menu.Name,
                                                                p.CategoryId,
                                                                p.Category.Name))
                                                        .ToList();
            return productsByCategory;
        }
    }
}
