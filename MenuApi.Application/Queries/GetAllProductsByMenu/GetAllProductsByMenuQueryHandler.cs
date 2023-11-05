using MediatR;
using MenuApi.Application.ViewModels;
using MenuApi.Infrastructure.Persistence.Repositories.Interfaces;

namespace MenuApi.Application.Queries.GetAllProductsByMenu
{
    public class GetAllProductsByMenuQueryHandler : IRequestHandler<GetAllProductsByMenuQuery, List<ProductViewModel>>
    {
        private readonly IProductRepository _productRepository;
        public GetAllProductsByMenuQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductViewModel>> Handle(GetAllProductsByMenuQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllByMenuAsync(request.IdMenu);

            var productsByMenu = products
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
            return productsByMenu;
        }
    }
}
