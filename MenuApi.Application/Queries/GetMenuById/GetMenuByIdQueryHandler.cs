using MediatR;
using MenuApi.Application.ViewModels;
using MenuApi.Infrastructure.Persistence.Repositories.Interfaces;

namespace MenuApi.Application.Queries.GetMenuById
{
    public class GetMenuByIdQueryHandler : IRequestHandler<GetMenuByIdQuery, MenuDetailsViewModel>
    {
        private readonly IMenuRepository _menuRepository;
        public GetMenuByIdQueryHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<MenuDetailsViewModel?> Handle(GetMenuByIdQuery request, CancellationToken cancellationToken)
        {
            var menu = await _menuRepository.GetDetailsById(request.Id);

            if (menu == null) return null;

            var menuDetails = new MenuDetailsViewModel(
                menu.Name,
                menu.Description,
                menu.Status,
                menu.Products);

            return menuDetails;

        }
    }
}
