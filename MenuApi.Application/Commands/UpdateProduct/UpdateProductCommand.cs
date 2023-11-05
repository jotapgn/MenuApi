using MediatR;

namespace MenuApi.Application.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<UpdateProductCommand>
    {
        public UpdateProductCommand(int id, string name, string description, decimal price, int menuId, int categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            MenuId = menuId;
            CategoryId = categoryId;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int MenuId { get; private set; }
        public int CategoryId { get; private set; }
    }
}
