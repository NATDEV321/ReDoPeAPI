using ReDoPeAPI.Context;
using ReDoPeAPI.GraphQL.Mutations.MutationReturnTypes;
using ReDoPeAPI.Models;
using ReDoPeAPI.Tools;

namespace ReDoPeAPI.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class UserMutation
    {
        public MutationReturnType AddUser(string firstname, string lastname, string email, string password, int roleId, int groupId, [Service] ApiContext context)
        {
            UserModel user = new()
            {
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                Password = PasswordHashing.CreateHash(password),
                RoleId = roleId,
                GroupId = groupId
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

        public MutationReturnType DeleteUser(string email, [Service] ApiContext context)
        {
            UserModel? user = context.Users.FirstOrDefault(u => u.Email == email);
            if(user is null)
            {
                return new MutationReturnType
                {
                    Code = 400,
                    Label = "Error",
                    Domain = "User",
                    Description = $"Couldn't remove user {email} because he doesn't exist"
                };
            }

            context.Users.Remove(user);
            context.SaveChanges();

            return new MutationReturnType
            {
                Code = 200,
                Label = "Success",
                Domain = "User",
                Description = $"User {email} has been removed successfully"
            };
        }

        public MutationReturnType UpdateUserGroup(string email, int groupId, [Service] ApiContext context)
        {
            UserModel? user = context.Users.FirstOrDefault(u => u.Email == email);
            if (user is null)
            {
                return new MutationReturnType
                {
                    Code = 400,
                    Label = "Error",
                    Domain = "User",
                    Description = $"Couldn't remove user {email} because he doesn't exist"
                };
            }

            bool doesGroupExist = context.Groups.Any(g => g.Id == groupId);
            if (!doesGroupExist)
            {
                return new MutationReturnType
                {
                    Code = 400,
                    Label = "Error",
                    Domain = "User",
                    Description = $"Couldn't add user {email} to group because group {groupId} doesn't exist"
                };
            }

            user.GroupId = groupId;
            context.SaveChanges();

            return new MutationReturnType
            {
                Code = 200,
                Label = "Success",
                Domain = "User",
                Description = $"User {email} has been removed successfully"
            };
        }
    }
}
