using MediatR;
using MenuApi.Application.ViewModels;

namespace MenuApi.Application.Queries.GetMenuById
{
    public class GetMenuByIdQuery : IRequest<MenuDetailsViewModel>
    {
        public GetMenuByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
