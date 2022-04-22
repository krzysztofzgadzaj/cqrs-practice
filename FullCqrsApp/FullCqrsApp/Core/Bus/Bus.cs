using MediatR;

namespace FullCqrsApp.Core.Bus
{
    public abstract class Bus
    {
        protected readonly IMediator Mediator;

        protected Bus(IMediator mediator) =>
            Mediator = mediator;
    }
}