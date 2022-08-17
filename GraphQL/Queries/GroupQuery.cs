using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ReDoPeAPI.Context;
using ReDoPeAPI.Models;

namespace ReDoPeAPI.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class GroupQuery
    {
        [Authorize]
        public IQueryable<GroupModel> GetGroups([Service] ApiContext context)
        {
            return context.Groups.Include(g => g.Users).AsQueryable();
        }
    }
}
