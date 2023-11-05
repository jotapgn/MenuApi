using MenuApi.Domain.Enum;

namespace MenuApi.Application.ViewModels
{
    public record MenuViewModel
    {
        public MenuViewModel(string name, string description, StatusMenu status)
        {
            Name = name;
            Description = description;
            Status = status;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public StatusMenu Status { get; private set; }
    }
}
