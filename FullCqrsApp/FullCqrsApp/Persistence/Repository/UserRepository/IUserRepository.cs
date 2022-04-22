using System.Collections.Generic;
using System.Threading.Tasks;
using FullCqrsApp.Persistence.Entities.User;

namespace FullCqrsApp.Persistence.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task<IEnumerable<User>> GetUsers();
    }
}