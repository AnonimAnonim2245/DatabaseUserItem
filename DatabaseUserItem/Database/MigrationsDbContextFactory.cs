using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace DatabaseUserItem.Database
{
    public class MigrationsDbContextFactory : IDesignTimeDbContextFactory<TodoContext>
    {
        public TodoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TodoContext>();

            optionsBuilder.UseSqlServer(args.Length > 0 ? args[0] : "", o =>
            {
                o.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            return new TodoContext(optionsBuilder.Options);
        }
    }
}
