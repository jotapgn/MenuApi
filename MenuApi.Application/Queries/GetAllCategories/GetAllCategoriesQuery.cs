using MediatR;
using MenuApi.Application.ViewModels;

namespace MenuApi.Application.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery: IRequest<List<CategoryViewModel>>
    {
    }
}
