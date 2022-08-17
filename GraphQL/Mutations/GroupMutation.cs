using ReDoPeAPI.Context;
using ReDoPeAPI.GraphQL.Mutations.MutationReturnTypes;
using ReDoPeAPI.Models;

namespace ReDoPeAPI.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class GroupMutation
    {
        public MutationReturnType AddGroup(string name, string description, [Service] ApiContext context)
        {
            GroupModel group = new()
            {
                Name = name,
                Description = description
            };

            try
            {
                context.Groups.Add(group);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return new MutationReturnType
                {
                    Code = 400,
                    Label = "Error",
                    Domain = "Group",
                    Description = ex.Message
                };
            }

            return new MutationReturnType
            {
                Code = 200,
                Label = "Success",
                Domain = "Group",
                Description = $"Group {name} has been successfully created"
            };
        }

        public MutationReturnType UpdateGroup(int id, string name, string description, [Service] ApiContext context)
        {
            GroupModel? group = context.Groups.FirstOrDefault(g => g.Id == id);
            if(group is null)
            {
                return new MutationReturnType
                {
                    Code = 400,
                    Label = "Error",
                    Domain = "Group",
                    Description = $"Group with id {id} do not exist"
                };
            }

            group.Name = name;
            group.Description = description;

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return new MutationReturnType
                {
                    Code = 400,
                    Label = "Error",
                    Domain = "Group",
                    Description = ex.Message
                };
            }

            return new MutationReturnType
            {
                Code = 200,
                Label = "Success",
                Domain = "Group",
                Description = $"Group {name} has been updated successfully"
            };
        }


    }
}
