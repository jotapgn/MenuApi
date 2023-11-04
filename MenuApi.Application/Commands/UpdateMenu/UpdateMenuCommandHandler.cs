using MediatR;
using MenuApi.Infrastructure.Persistence.Repositories.Interfaces;

namespace MenuApi.Application.Commands.UpdateMenu
{
    public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommand, UpdateMenuCommand>
    {
        public readonly IMenuRepository _menuRepository;
        public UpdateMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<UpdateMenuCommand?> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = await _menuRepository.GetByIdAsync(request.Id);

            if (menu == null) return null;

            menu.Update(request.Name, request.Description, request.Status);

            await _menuRepository.SaveAsync();

            var newMenu = await _menuRepository.GetByIdAsync(request.Id);

            if (newMenu == null) return null;

            return new UpdateMenuCommand(
                newMenu.Id,
                newMenu.Name,
                newMenu.Description,
                newMenu.Status
                );   
        }
    }
}
