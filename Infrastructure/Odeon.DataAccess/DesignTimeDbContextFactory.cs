using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Odeon.DataAccess.Contexts;

namespace Odeon.DataAccess
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OdeonDbContext>
    {
        public OdeonDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<OdeonDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString, b => b.MigrationsAssembly("Odeon.DataAccess"));
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
