
namespace TaskoMask.BuildingBlocks.Infrastructure.EntityFramework
{
    public class EFDatabaseOptions
    {
        public string Connection { get; set; }
        public string DatabaseName { get; set; }
        public EFDatabaseType DatabaseType { get; set; }
    }

    public enum EFDatabaseType
    {
        SqlServer,
        Sqlite,
        PostgreSQL,
        InMemoryDatabase
    }
}
