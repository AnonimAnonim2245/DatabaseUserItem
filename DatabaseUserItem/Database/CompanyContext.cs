using Microsoft.EntityFrameworkCore;
using DatabaseUserItem.Models;

namespace DatabaseUserItem.Database
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options)
        {
        }
        public DbSet<Company> Teams { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
}
