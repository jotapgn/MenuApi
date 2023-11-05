using MenuApi.Domain.Entities;
using MenuApi.Domain.Enum;

namespace MenuApi.Application.ViewModels
{
    public record MenuDetailsViewModel
    {
        public MenuDetailsViewModel(string name, string description, StatusMenu status, List<ProductEntity> products)
        {
            Name = name;
            Description = description;
            Status = status;
            Products = products;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public StatusMenu Status { get; private set; }
        public List<ProductEntity> Products { get; private set; }

    }
}
