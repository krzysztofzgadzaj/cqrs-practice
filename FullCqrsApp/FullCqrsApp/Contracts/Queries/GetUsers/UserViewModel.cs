using FullCqrsApp.Contracts.Base.Mapping;
using FullCqrsApp.Contracts.Base.Mapping.MappingRegister;
using FullCqrsApp.Persistence.Entities.User;

namespace FullCqrsApp.Contracts.Queries.GetUsers
{
    public class UserViewModel
        : ViewModelMappingRegister<User>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}