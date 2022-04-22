using System.Threading;
using System.Threading.Tasks;
using FullCqrsApp.Contracts.Queries.Base;
using MediatR;

namespace FullCqrsApp.Core.Bus.QueryBus
{
    public class QueryBus : Bus, IQueryBus
    {
        public QueryBus(IMediator mediator) 
            : base(mediator)
        {
        }

        public async Task<TResult> QueryAsync<TResult>(
            IQuery<TResult> query,
            CancellationToken cancellationToken = default) =>
                await Mediator.Send(query, cancellationToken);
    }
}