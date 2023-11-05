using MediatR;

namespace MenuApi.Application.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public DeleteProductCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
