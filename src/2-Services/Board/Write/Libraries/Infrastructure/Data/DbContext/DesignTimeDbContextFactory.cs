using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TaskoMask.BuildingBlocks.Infrastructure.EntityFramework;

namespace TaskoMask.Services.Board.Infrastructure.Data.DbContext
{
    /// <summary>
    /// Only used by EF Tooling
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BoardWriteDbContext>
    {
        public BoardWriteDbContext CreateDbContext(string[] args)
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
                .Build();

            var entityFrameworkSection = configuration.GetSection("EntityFramework").Get<EFCoreDbOptions>();
            var dbOptions = Options.Create(entityFrameworkSection);

            return new BoardWriteDbContext(dbOptions);
        }
    }
}
