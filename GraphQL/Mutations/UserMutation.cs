using ReDoPeAPI.Context;
using ReDoPeAPI.GraphQL.Mutations.MutationReturnTypes;
using ReDoPeAPI.Models;

namespace ReDoPeAPI.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class UserMutation
    {
        public MutationReturnType AddUser(string firstname, string lastname, string email, string password, int roleId, [Service] ApiContext context)
        {
            UserModel user = new()
            {
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                Password = password,
                RoleId = roleId
            };

            try
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                return new MutationReturnType
                {
                    Code = 400,
                    Label = "Error",
                    Domain = "User",
                    Description = ex.Message
                };
            }

            return new MutationReturnType
            {
                Code = 200,
                Label = "Success",
                Domain = "User",
                Description = String.Format("User {0} {1} has been added successfully", firstname, lastname)
            };
        }
    }
}
