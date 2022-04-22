using MediatR;

namespace FullCqrsApp.Contracts.Queries.Base
{
    public interface IQuery<TResult>
        : IRequest<TResult>
    {
    }
}