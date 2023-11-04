using MediatR;
using MenuApi.Application.ViewModels;
using MenuApi.Infrastructure.Persistence.Repositories.Interfaces;

namespace MenuApi.Application.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryViewModel>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryViewModel>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();

            var categoriesViewModel = categories
                                        .Select(c => new CategoryViewModel(c.Id, c.Name))
                                        .ToList();
            return categoriesViewModel;
        }
    }
}
