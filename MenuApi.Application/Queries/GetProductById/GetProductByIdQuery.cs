using MediatR;
using MenuApi.Application.ViewModels;

namespace MenuApi.Application.Queries.GetProductById
{
    public class GetProductByIdQuery: IRequest<ProductViewModel>
    {
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
