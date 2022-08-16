using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using ReDoPeAPI.GraphQL.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddDbContext

builder.Services.AddGraphQLServer()
                .AddQueryType(q => q.Name("Query"))
                .AddType<UserQuery>()
                .AddMutationType(m => m.Name("Mutation"));

builder.Services.AddCors(options => options.AddPolicy("AllowOrigin", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseRouting();
//app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapControllers();

app.UsePlayground(new PlaygroundOptions
{
      QueryPath = "/graphql",
      Path = "/playground"
});

/*app.UseEndpoints(endpoints =>
    endpoints.MapGraphQL()
);*/

app.Run();
