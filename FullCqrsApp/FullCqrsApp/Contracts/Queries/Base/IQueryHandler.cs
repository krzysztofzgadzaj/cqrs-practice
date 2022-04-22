using MediatR;

namespace FullCqrsApp.Contracts.Queries.Base
{
    public interface IQueryHandler<TQuery, TResult>
        : IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
    }
}