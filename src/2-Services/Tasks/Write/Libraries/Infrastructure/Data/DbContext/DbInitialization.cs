using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace TaskoMask.Services.Tasks.Write.Infrastructure.Data.DbContext
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
        /// Seed the necessary data that system needs
        /// </summary>
        public static void SeedEssentialData(this IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<TaskWriteDbContext>();

            // dbContext.Boards.InsertOneAsync(x)
        }



        /// <summary>
        /// Create index for collections
        /// </summary>
        public static void CreateIndexes(this IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<TaskWriteDbContext>();

            dbContext.Tasks.Indexes.CreateOneAsync(new CreateIndexModel<Task>(Builders<Task>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = nameof(Task.Id), Unique = true }));
            dbContext.Tasks.Indexes.CreateOneAsync(new CreateIndexModel<Task>(Builders<Task>.IndexKeys.Ascending(x => x.CardId.Value), new CreateIndexOptions() { Name = nameof(Task.CardId) }));

        }

    }
}
