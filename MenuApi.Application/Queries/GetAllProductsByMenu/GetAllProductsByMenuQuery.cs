using MediatR;
using MenuApi.Application.ViewModels;

namespace MenuApi.Application.Queries.GetAllProductsByMenu
{
    public class GetAllProductsByMenuQuery: IRequest<List<ProductViewModel>>
    {
        public GetAllProductsByMenuQuery(int id)
        {
            IdMenu = id;
        }

        public int IdMenu { get; private set; }
    }
}
