using MediatR;

namespace MenuApi.Application.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public CreateProductCommand(string name, string description, decimal price, int menuId, int categoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            MenuId = menuId;
            CategoryId = categoryId;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int MenuId { get; private set; }
        public int CategoryId { get; private set; }
    }
}
