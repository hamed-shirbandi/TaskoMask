using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using TaskoMask.Services.Owners.Write.Domain.Entities;

namespace TaskoMask.Services.Owners.Write.Infrastructure.Data.DbContext
{

    /// <summary>
    /// 
    /// </summary>
    public static class DbInitialization
    {


        /// <summary>
        /// 
        /// </summary>
        public static void InitialDatabasesAndSeedEssentialData(this IServiceProvider serviceProvider)
        {
            serviceProvider.SeedEssentialData();
            serviceProvider.CreateIndexes();
        }



        /// <summary>
        /// Drop database
        /// </summary>
        public static void DropDatabase(this IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.CreateScope();

            var dbContext = serviceScope.ServiceProvider.GetService<OwnerWriteDbContext>();

            dbContext.DropDatabase();
        }



        /// <summary>
        /// Seed the necessary data that system needs
        /// </summary>
        private static void SeedEssentialData(this IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<OwnerWriteDbContext>();

            // dbContext.Owners.InsertOneAsync(x)
        }



        /// <summary>
        /// Create index for collections
        /// </summary>
        private static void CreateIndexes(this IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<OwnerWriteDbContext>();

            dbContext.Owners.Indexes.CreateOneAsync(new CreateIndexModel<Owner>(Builders<Owner>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = nameof(Owner.Id), Unique = true }));
            dbContext.Owners.Indexes.CreateOneAsync(new CreateIndexModel<Owner>(Builders<Owner>.IndexKeys.Ascending(x => x.Email.Value), new CreateIndexOptions() { Name = nameof(Owner.Email), Unique = true }));
            dbContext.Owners.Indexes.CreateOneAsync(new CreateIndexModel<Owner>(Builders<Owner>.IndexKeys.Ascending(x => x.DisplayName.Value), new CreateIndexOptions() { Name = nameof(Owner.DisplayName) }));
        }

    }
}
