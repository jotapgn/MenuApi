using MediatR;
using MenuApi.Application.ViewModels;
using MenuApi.Infrastructure.Persistence.Repositories.Interfaces;

namespace MenuApi.Application.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductViewModel>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductViewModel?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetDetailsById(request.Id);

            if (product == null) return null;

            return new ProductViewModel(
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.MenuId,
                product.Menu.Name,
                product.CategoryId,
                product.Category.Name);
        }
    }
}
