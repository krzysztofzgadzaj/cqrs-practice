using MediatR;

namespace FullCqrsApp.Contracts.Commands.Base
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
        where TCommand : ICommand
    {
    }
}