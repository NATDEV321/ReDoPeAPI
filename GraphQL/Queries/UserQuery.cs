using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ReDoPeAPI.Context;
using ReDoPeAPI.Models;

namespace ReDoPeAPI.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class UserQuery
    {
        [Authorize]
        public IQueryable<UserModel> GetUsers([Service] ApiContext context)
        {
            return context.Users.Include(u => u.Role).Include(u => u.Group).AsQueryable();
        }
    }
}
