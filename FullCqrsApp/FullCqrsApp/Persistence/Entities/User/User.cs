using System;
using FullCqrsApp.Persistence.Entities.Base;

namespace FullCqrsApp.Persistence.Entities.User
{
    public class User 
        : BaseEntity
    {
        public User(Guid id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
    }
}