using Microsoft.EntityFrameworkCore;
using ReDoPeAPI.Models;

namespace ReDoPeAPI.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
    }
}
