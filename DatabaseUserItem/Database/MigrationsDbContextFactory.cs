using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace DatabaseUserItem.Database
{
    public class MigrationsDbContextFactory : IDesignTimeDbContextFactory<CompanyContext>
    {
        public CompanyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CompanyContext>();

            optionsBuilder.UseSqlServer(args.Length > 0 ? args[0] : "", o =>
            {
                o.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            return new CompanyContext(optionsBuilder.Options);
        }
    }
}
