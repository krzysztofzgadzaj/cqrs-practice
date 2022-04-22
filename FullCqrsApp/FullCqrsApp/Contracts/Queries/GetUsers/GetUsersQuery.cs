using System.Collections.Generic;
using FullCqrsApp.Contracts.Queries.Base;

namespace FullCqrsApp.Contracts.Queries.GetUsers
{
    public class GetUsersQuery
        : IQuery<IEnumerable<UserViewModel>>
    {
    }
}