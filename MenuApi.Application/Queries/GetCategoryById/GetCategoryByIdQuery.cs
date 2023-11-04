using MediatR;
using MenuApi.Application.ViewModels;

namespace MenuApi.Application.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery: IRequest<CategoryViewModel>
    {
        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

    }
}
