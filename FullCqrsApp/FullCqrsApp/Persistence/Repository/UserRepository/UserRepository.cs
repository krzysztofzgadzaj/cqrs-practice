using System.Collections.Generic;
using System.Threading.Tasks;
using FullCqrsApp.Persistence.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace FullCqrsApp.Persistence.Repository.UserRepository
{
    public class UserRepository
        : IUserRepository
    {
        private readonly WriteContext _writeContext;

        public UserRepository(WriteContext context) =>
            _writeContext = context;

        public async Task AddUser(User user)
        {
            await _writeContext.Users.AddAsync(user);
            await _writeContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetUsers() =>
            await _writeContext
                .Users
                .ToListAsync();
    }
}