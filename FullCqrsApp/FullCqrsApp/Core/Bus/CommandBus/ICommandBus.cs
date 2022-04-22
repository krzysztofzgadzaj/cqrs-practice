using System.Threading;
using System.Threading.Tasks;
using FullCqrsApp.Contracts.Commands.Base;

namespace FullCqrsApp.Core.Bus.CommandBus
{
    public interface ICommandBus
    {
        Task CommandAsync(ICommand command, CancellationToken cancellationToken = default);
    }
}