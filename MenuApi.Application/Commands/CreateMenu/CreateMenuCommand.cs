using MediatR;
using MenuApi.Domain.Enum;

namespace MenuApi.Application.Commands.CreateMenu
{
    public class CreateMenuCommand: IRequest<int>
    {
        public CreateMenuCommand(string name, string description, StatusMenu status)
        {
            Name = name;
            Description = description;
            Status = status;
        }

        public string Name { get;  private set; }
        public string Description { get; private set; }
        public StatusMenu Status { get; private set; }
    }
}
