using MediatR;
using MenuApi.Domain.Entities;
using MenuApi.Infrastructure.Persistence.Repositories.Interfaces;

namespace MenuApi.Application.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new ProductEntity(request.Name, 
                                            request.Description,
                                            request.Price,
                                            request.MenuId,
                                            request.CategoryId);

            await _productRepository.AddAsync(product);
            await _productRepository.SaveAsync();
            return product.Id;
        }
    }
}
