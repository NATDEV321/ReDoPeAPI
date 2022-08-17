using GraphQL;
using ReDoPeAPI.Context;
using ReDoPeAPI.Models;

namespace ReDoPeAPI.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class RoleQuery
    {
        [Authorize]
        public IQueryable<RoleModel> GetRoles([Service] ApiContext context)
        {
            return context.Roles.AsQueryable();
        }
    }
}
