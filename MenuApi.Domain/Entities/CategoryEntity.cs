﻿namespace MenuApi.Domain.Entities
{
    public class CategoryEntity: BaseEntity
    {
        public CategoryEntity(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }

        public void Update(string name)
        {
            this.Name = name;
        }
    }
}