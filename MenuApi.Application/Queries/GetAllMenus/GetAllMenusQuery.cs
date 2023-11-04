using MediatR;
using MenuApi.Application.ViewModels;

namespace MenuApi.Application.Queries.GetAllMenus
{
    public class GetAllMenusQuery : IRequest<List<MenuViewModel>>
    {

    }
}
