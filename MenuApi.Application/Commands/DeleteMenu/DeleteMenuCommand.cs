using MediatR;

namespace MenuApi.Application.Commands.DeleteMenu
{
    public class DeleteMenuCommand: IRequest<Unit>
    {
        public DeleteMenuCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
