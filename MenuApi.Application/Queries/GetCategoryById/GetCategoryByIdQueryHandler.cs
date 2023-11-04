using MediatR;
using MenuApi.Application.ViewModels;
using MenuApi.Infrastructure.Persistence.Repositories.Interfaces;

namespace MenuApi.Application.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryViewModel>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryViewModel?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetDetailsById(request.Id);

            if (category == null) return null;

            return new CategoryViewModel(category.Id, category.Name);
        }
    }
}
