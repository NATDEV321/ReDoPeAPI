using ReDoPeAPI.Context;
using ReDoPeAPI.GraphQL.Mutations.MutationReturnTypes;
using ReDoPeAPI.Models;

namespace ReDoPeAPI.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class RoleMutation
    {
        public MutationReturnType AddRole(string name, [Service] ApiContext context)
        {
            RoleModel role = new()
            {
                Name = name
            };

            try
            {
                context.Roles.Add(role);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return new MutationReturnType
                {
                    Code = 400,
                    Label = "Error",
                    Domain = "Roles",
                    Description = ex.Message
                };
            }

            return new MutationReturnType
            {
                Code = 200,
                Label = "Success",
                Domain = "Roles",
                Description = String.Format("Role {0} has been added successfully", name)
            };
        }
    }
}
