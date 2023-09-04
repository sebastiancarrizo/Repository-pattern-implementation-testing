using Microsoft.EntityFrameworkCore;
using Test.Data.Models;

namespace Test.Data.Context
{
    public class PermissionContext : DbContext
    {
        public PermissionContext(DbContextOptions<PermissionContext> options) : base(options)
        {

        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }
    }
}
