using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using TaskoMask.Services.Identity.Domain.Entities;
using TaskoMask.Services.Identity.Infrastructure.DbContext;

namespace TaskoMask.Services.Identity.Infrastructure.DataProviders
{

    /// <summary>
    /// 
    /// </summary>
    public static class DbInitialization
    {

        /// <summary>
        /// Create collections and set indexes
        /// </summary>
        public static void Initial( IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<IIdentityDbContext>();

                CreateIndexes(dbContext);
            }
        }




        /// <summary>
        /// Create index for collections
        /// </summary>
        private static void CreateIndexes(IIdentityDbContext dbContext)
        {
            #region User Indexs

            dbContext.GetCollection<User>().Indexes.CreateOneAsync(new CreateIndexModel<User>(Builders<User>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = nameof(User.Id), Unique = true }));
            dbContext.GetCollection<User>().Indexes.CreateOneAsync(new CreateIndexModel<User>(Builders<User>.IndexKeys.Ascending(x => x.UserName), new CreateIndexOptions() { Name = nameof(User.UserName), Unique = true }));


            #endregion
        }



        /// <summary>
        /// Drop database
        /// </summary>
        public static void DropDatabase(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<IIdentityDbContext>();

                dbContext.DropDatabase();
            }
        }


    }
}
