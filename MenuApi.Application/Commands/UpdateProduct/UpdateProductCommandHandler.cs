using MediatR;
using MenuApi.Infrastructure.Persistence.Repositories.Interfaces;

namespace MenuApi.Application.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<UpdateProductCommand?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetDetailsById(request.Id);
            if (product == null)
                return null;

            product.Update(request.Name, request.Description, request.Price, request.MenuId, request.CategoryId);
            await _productRepository.SaveAsync();

            var newProduct = await _productRepository.GetDetailsById(request.Id);
            if (newProduct == null)
                return null;

            return new UpdateProductCommand(newProduct.Id,
                                            newProduct.Name,
                                            newProduct.Description,
                                            newProduct.Price,
                                            newProduct.MenuId,
                                            newProduct.CategoryId);
        }
    }
}
