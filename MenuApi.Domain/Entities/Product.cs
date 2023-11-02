namespace MenuApi.Domain.Entities
{
    public class Product:BaseEntity
    {
        public Product(string name, string description, decimal price, Category category)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public Category Category { get; private set; }
    }
}
