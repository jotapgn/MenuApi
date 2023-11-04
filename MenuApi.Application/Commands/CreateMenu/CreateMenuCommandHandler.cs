using MediatR;
using MenuApi.Domain.Entities;
using MenuApi.Infrastructure.Persistence.Repositories.Interfaces;

namespace MenuApi.Application.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, int>
    {
        private readonly IMenuRepository _menuRepository;
        public CreateMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public async Task<int> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = new MenuEntity(request.Name, request.Description, request.Status);
            await _menuRepository.AddAsync(menu);
            await _menuRepository.SaveAsync();
            return menu.Id;
        }
    }
}
