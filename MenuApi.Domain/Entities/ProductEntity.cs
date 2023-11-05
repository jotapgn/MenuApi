namespace MenuApi.Domain.Entities
{
    public class ProductEntity:BaseEntity
    {
        public ProductEntity(string name, string description, decimal price, int menuId, int categoryId)
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
        public MenuEntity Menu { get; private set; }
        public int CategoryId { get; private set; }
        public CategoryEntity Category { get; private set; }

        public void Update(string name, string description, decimal price, int menuId, int categoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            MenuId = menuId;
            CategoryId = categoryId;
        }
    }
}
