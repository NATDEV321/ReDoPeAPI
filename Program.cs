using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.EntityFrameworkCore;
using ReDoPeAPI.Context;
using ReDoPeAPI.GraphQL.Mutations;
using ReDoPeAPI.GraphQL.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiContext>(context => context.UseInMemoryDatabase("RedopeApiServer"));

builder.Services.AddGraphQLServer()
                .AddType<UserQuery>()
                .AddType<RoleQuery>()
                .AddQueryType(q => q.Name("Query"))
                .AddMutationType(m => m.Name("Mutation"))
                .AddType<UserMutation>()
                .AddType<RoleMutation>()
                .AddType<GroupMutation>()
                .AddProjections()
                .AddFiltering()
                .AddSorting();

builder.Services.AddCors(options => options.AddPolicy("AllowOrigin", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseRouting();

app.UsePlayground(new PlaygroundOptions
{
      QueryPath = "/graphql",
      Path = "/playground"
});

app.UseEndpoints(endpoints =>
    endpoints.MapGraphQL()
);

app.Run();
