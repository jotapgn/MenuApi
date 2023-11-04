using MediatR;

namespace MenuApi.Application.Commands.DeleteCategory
{
    public class DeleteCategoryCommand: IRequest<Unit>
    {
        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
