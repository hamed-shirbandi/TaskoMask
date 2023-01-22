using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using TaskoMask.Services.Monolith.Infrastructure.Data.Read.DbContext;
using System;

namespace TaskoMask.Services.Monolith.Infrastructure.Data.Read.DataProviders
{

    /// <summary>
    /// 
    /// </summary>
    public static class ReadDbInitialization
    {

        /// <summary>
        /// Create collections and set indexes
        /// </summary>
        public static void Initial( IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<IReadDbContext>();

                CreateIndexes(dbContext);
            }
        }



        /// <summary>
        /// Create index for collections
        /// </summary>
        private static void CreateIndexes(IReadDbContext dbContext)
        {
        }



        /// <summary>
        /// Drop database
        /// </summary>
        public static void DropDatabase(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<IReadDbContext>();

                dbContext.DropDatabase();
            }
        }


    }
}
