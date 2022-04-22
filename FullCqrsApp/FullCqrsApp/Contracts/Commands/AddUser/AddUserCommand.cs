using System;
using FullCqrsApp.Contracts.Base.Mapping.MappingRegister;
using FullCqrsApp.Contracts.Commands.Base;
using FullCqrsApp.Persistence.Entities.User;

namespace FullCqrsApp.Contracts.Commands.AddUser
{
    public class AddUserCommand
        : CommandMappingRegister<User>, ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}