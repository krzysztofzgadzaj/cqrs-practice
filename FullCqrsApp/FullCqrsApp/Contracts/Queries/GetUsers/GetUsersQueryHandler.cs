using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FullCqrsApp.Contracts.Queries.Base;
using FullCqrsApp.Persistence.Repository.UserRepository;

namespace FullCqrsApp.Contracts.Queries.GetUsers
{
    public class GetUsersQueryHandler
        : IQueryHandler<GetUsersQuery, IEnumerable<UserViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(
            IMapper mapper,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        
        public async Task<IEnumerable<UserViewModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsers();

            return _mapper.Map<IEnumerable<UserViewModel>>(users);
        }
    }
}