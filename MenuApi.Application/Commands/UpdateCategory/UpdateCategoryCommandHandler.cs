using MediatR;
using MenuApi.Infrastructure.Persistence.Repositories.Interfaces;

namespace MenuApi.Application.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<UpdateCategoryCommand?> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetDetailsById(request.Id);
            if (category == null) return null;

            category.Update(request.Name);

            await _categoryRepository.SaveAsync();

            var newCategory = await _categoryRepository.GetDetailsById(request.Id);

            if (newCategory == null) return null;

            return new UpdateCategoryCommand(newCategory.Id, newCategory.Name);
        }
    }
}
