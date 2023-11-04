using MediatR;
using MenuApi.Application.ViewModels;
using MenuApi.Infrastructure.Persistence.Repositories.Interfaces;


namespace MenuApi.Application.Queries.GetAllMenus
{
    public class GetAllMenusQueryHandler : IRequestHandler<GetAllMenusQuery, List<MenuViewModel>>
    {
        private readonly IMenuRepository _menuRepository;
        public GetAllMenusQueryHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<List<MenuViewModel>> Handle(GetAllMenusQuery request, CancellationToken cancellationToken)
        {
            var menus = await _menuRepository.GetAllAsync();
            var menusViewModel = menus
                                .Select(m => new MenuViewModel(m.Name,m.Description, m.Status))
                                .ToList();

            return menusViewModel;
        }
    }
}
