using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace TaskoMask.BuildingBlocks.Infrastructure.EntityFramework
{
    public abstract class EFCoreDbContext: DbContext
    {
        private readonly EFCoreDbOptions _databaseOptions;

        public EFCoreDbContext(IOptions<EFCoreDbOptions> databaseOptions)
        {
            _databaseOptions = databaseOptions.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            switch (_databaseOptions.DatabaseType)
            {
                case EFDatabaseType.SqlServer:
                    optionsBuilder.UseSqlServer(_databaseOptions.Connection.Replace("[DatabaseName]", _databaseOptions.DatabaseName));
                    break;
                case EFDatabaseType.Sqlite:
                    optionsBuilder.UseSqlite(_databaseOptions.Connection.Replace("[DatabaseName]", _databaseOptions.DatabaseName));
                    break;
                case EFDatabaseType.PostgreSQL:
                    optionsBuilder.UseNpgsql(_databaseOptions.Connection.Replace("[DatabaseName]", _databaseOptions.DatabaseName));
                    break;
                case EFDatabaseType.InMemoryDatabase:
                    optionsBuilder.UseInMemoryDatabase(databaseName: _databaseOptions.DatabaseName);
                    break;
            }
        }
    }
}
