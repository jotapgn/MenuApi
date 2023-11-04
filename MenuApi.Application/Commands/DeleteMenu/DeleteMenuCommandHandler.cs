using MediatR;
using MenuApi.Infrastructure.Persistence.Repositories.Interfaces;

namespace MenuApi.Application.Commands.DeleteMenu
{
    public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommand, Unit>
    {
        public readonly IMenuRepository _menuRepository;
        public DeleteMenuCommandHandler(IMenuRepository menuRepository) { 
            _menuRepository = menuRepository;
        }

        public async Task<Unit> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            await _menuRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
