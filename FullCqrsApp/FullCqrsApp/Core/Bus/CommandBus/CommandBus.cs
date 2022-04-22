using System.Threading;
using System.Threading.Tasks;
using FullCqrsApp.Contracts.Commands.Base;
using MediatR;

namespace FullCqrsApp.Core.Bus.CommandBus
{
    public class CommandBus : Bus, ICommandBus
    {
        public CommandBus(IMediator mediator) 
            : base(mediator)
        {
        }

        public async Task CommandAsync(ICommand command, CancellationToken cancellationToken = default) =>
            await Mediator.Send(command, cancellationToken);
    }
}