using System.Collections.Generic;
using System.Threading.Tasks;
using FullCqrsApp.Contracts.Commands.AddUser;
using FullCqrsApp.Contracts.Queries.GetUsers;
using FullCqrsApp.Controllers.Base;
using FullCqrsApp.Core.Bus.CommandBus;
using FullCqrsApp.Core.Bus.QueryBus;
using Microsoft.AspNetCore.Mvc;

namespace FullCqrsApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BasisController
    {
        public UserController(
            IQueryBus queryBus, 
            ICommandBus commandBus) 
                : base(queryBus, commandBus)
        {
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsers([FromQuery] GetUsersQuery query)
        {
            var result = await QueryBus.QueryAsync(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserCommand command)
        {
            await CommandBus.CommandAsync(command);

            return Ok();
        }
    }
}