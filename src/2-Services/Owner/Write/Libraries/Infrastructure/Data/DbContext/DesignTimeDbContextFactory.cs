using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TaskoMask.Services.Owner.Infrastructure.Data.DbContext
{
    /// <summary>
    /// Only used by EF Tooling
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OwnerDbContext>
    {
        public OwnerDbContext CreateDbContext(string[] args)
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
                .Build();

            return new IdentityDbContext(configuration);
        }
    }
}
