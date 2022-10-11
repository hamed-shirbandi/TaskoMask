using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TaskoMask.BuildingBlocks.Infrastructure.EntityFramework;

namespace TaskoMask.Services.Owner.Infrastructure.Data.DbContext
{
    public class OwnerWriteDbContext : EFBaseDbContext
    {
        public OwnerWriteDbContext(IOptions<EFDatabaseOptions> options):base(options)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           base.OnConfiguring(optionsBuilder);
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
