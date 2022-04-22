using System.Threading;
using System.Threading.Tasks;
using FullCqrsApp.Contracts.Queries.Base;

namespace FullCqrsApp.Core.Bus.QueryBus
{
    public interface IQueryBus
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
    }
}