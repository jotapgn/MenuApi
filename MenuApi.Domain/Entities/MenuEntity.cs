﻿using MenuApi.Domain.Enum;

namespace MenuApi.Domain.Entities
{
    public class MenuEntity: BaseEntity
    {
        public MenuEntity(string name, string description, StatusMenu status)
        {
            Name = name;
            Description = description;
            Products = new List<ProductEntity>();
            Status = status;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public StatusMenu Status { get; private set; }
        public List<ProductEntity> Products { get; private set; }      
        public void Update(string Name, string desciption, StatusMenu status)
        {
            this.Name = Name;
            this.Description = desciption;
            this.Status = status;
        }
        public void Activate()
        {
            Status = StatusMenu.Ative;
        }
        public void Inactivate()
        {
            Status = StatusMenu.Inactive;
        }
    }
}
