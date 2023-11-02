using MenuApi.Domain.Enum;

namespace MenuApi.Domain.Entities
{
    public class MenuEntity: BaseEntity
    {
        public MenuEntity(string name, string description, StatusMenu status)
        {
            Name = name;
            Description = description;
            Products = new List<Product>();
            Status = status;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public StatusMenu Status { get; private set; }
        public List<Product> Products { get; private set; }      
        public void Activate()
        {
            Status = StatusMenu.Ative;
        }
        public void Inativate()
        {
            Status = StatusMenu.Inative;
        }
    }
}
