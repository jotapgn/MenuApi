using MediatR;
using MenuApi.Application.ViewModels;

namespace MenuApi.Application.Queries.GetAllProductsByCategory
{
    public class GetAllProductsByCategoryQuery: IRequest<List<ProductViewModel>>
    {
        public GetAllProductsByCategoryQuery(int idCategory)
        {
            IdCategory = idCategory;
        }

        public int IdCategory {  get; private set; }
    }
}
