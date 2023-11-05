namespace MenuApi.Application.ViewModels
{
    public record ProductViewModel
    {
        public ProductViewModel(int id, string name, string description, decimal price, int menuId, string menuName, int categoryId, string categoryName)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            MenuId = menuId;
            MenuName = menuName;
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int MenuId { get; private set; }
        public string MenuName { get; private set; }
        public int CategoryId { get; private set; }
        public string CategoryName { get; private set; }
    }
}
