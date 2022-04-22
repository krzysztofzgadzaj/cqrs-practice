using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FullCqrsApp.Contracts.Commands.Base;
using FullCqrsApp.Persistence.Entities.User;
using FullCqrsApp.Persistence.Repository.UserRepository;
using MediatR;

namespace FullCqrsApp.Contracts.Commands.AddUser
{
    public class AddUserCommandHandler
        : ICommandHandler<AddUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AddUserCommandHandler(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        
        public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<User>(request);

            await _userRepository.AddUser(entity);
            
            return Unit.Value;
        }
    }
}