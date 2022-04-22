using FullCqrsApp.Core.Bus.CommandBus;
using FullCqrsApp.Core.Bus.QueryBus;
using Microsoft.AspNetCore.Mvc;

namespace FullCqrsApp.Controllers.Base
{
    public class BasisController : ControllerBase
    {
        protected readonly IQueryBus QueryBus;
        protected readonly ICommandBus CommandBus;

        public BasisController(IQueryBus queryBus, ICommandBus commandBus)
        {
            QueryBus = queryBus;
            CommandBus = commandBus;
        }
    }
}