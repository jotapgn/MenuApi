using MediatR;
using MenuApi.Domain.Enum;

namespace MenuApi.Application.Commands.UpdateMenu
{
    public class UpdateMenuCommand : IRequest<UpdateMenuCommand>

    {
        public UpdateMenuCommand(int id, string name, string description, StatusMenu status)
        {
            Id = id;
            Name = name;
            Description = description;
            Status = status;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public StatusMenu Status { get; private set; }
    }
}
