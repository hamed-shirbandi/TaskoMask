using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Domain.Models;

namespace TaskoMask.BuildingBlocks.Infrastructure.EntityFramework
{
    public abstract class EFCoreDbContext: DbContext, IUnitOfWork
    {
        #region Fields

        private readonly EFCoreDbOptions _databaseOptions;

        #endregion

        #region Ctors

        public EFCoreDbContext(IOptions<EFCoreDbOptions> databaseOptions)
        {
            _databaseOptions = databaseOptions.Value;
        }

        #endregion

        #region Protected Methods

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

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public void MarkAsModified<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            base.Entry(entity).State = EntityState.Modified; // Or use ---> this.Update(entity);
        }



        /// <summary>
        /// 
        /// </summary>
        public void MarkAsDeleted<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            base.Entry<TEntity>(entity).State = EntityState.Deleted;

        }



        /// <summary>
        /// 
        /// </summary>
        public int SaveChanges()
        {
            return base.SaveChanges();
        }




        /// <summary>
        /// 
        /// </summary>
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        #endregion

    }
}
