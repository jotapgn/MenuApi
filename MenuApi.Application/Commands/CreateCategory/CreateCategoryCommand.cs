using MediatR;

namespace MenuApi.Application.Commands.CreateCategory
{
    public class CreateCategoryCommand: IRequest<int>
    {
        public CreateCategoryCommand(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
