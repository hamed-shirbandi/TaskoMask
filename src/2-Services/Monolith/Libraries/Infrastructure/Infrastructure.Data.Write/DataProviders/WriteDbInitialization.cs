using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.DbContext;

namespace TaskoMask.Services.Monolith.Infrastructure.Data.Write.DataProviders
{

    /// <summary>
    /// 
    /// </summary>
    public static class WriteDbInitialization
    {

        /// <summary>
        /// Create collections and set indexes
        /// </summary>
        public static void Initial( IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<IWriteDbContext>();

                CreateIndexes(dbContext);
            }
        }




        /// <summary>
        /// Create index for collections
        /// </summary>
        private static void CreateIndexes(IWriteDbContext dbContext)
        {
        }



        /// <summary>
        /// Drop database
        /// </summary>
        public static void DropDatabase(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<IWriteDbContext>();

                dbContext.DropDatabase();
            }
        }


    }
}
