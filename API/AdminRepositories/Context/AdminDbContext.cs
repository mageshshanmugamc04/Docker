using DomainModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdminRepositories.Context
{
    public class AdminDbContext(DbContextOptions<AdminDbContext> options) : DbContext(options)
    {
        public DbSet<User> User { get; set; }
        public DbSet<Menu> Menu { get; set; }
    }
}