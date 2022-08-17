using Microsoft.EntityFrameworkCore;
using ReDoPeAPI.Models;

namespace ReDoPeAPI.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<UserModel>()
                .HasOne(u => u.Group)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.GroupId);
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<GroupModel> Groups { get; set; }
    }
}
