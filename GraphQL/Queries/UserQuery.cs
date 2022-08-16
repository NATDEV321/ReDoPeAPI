using ReDoPeAPI.Models;

namespace ReDoPeAPI.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class UserQuery
    {
        public IQueryable<UserModel> GetUsers()
        {
            return (new List<UserModel>() { new UserModel { FirstName = "allo", LastName = "ouais" } }).AsQueryable();
        }
    }
}
