using MongoDB.Driver;

namespace TaskoMask.Services.Task.Read.Api.Infrastructure.DbContext
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
            var dbContext = serviceScope.ServiceProvider.GetService<TaskReadDbContext>();
            var configuration = serviceScope.ServiceProvider.GetService<IConfiguration>();

            // var boards = dbContext.GetCollection<Task>();
            // seed data ...
        }



        /// <summary>
        /// Create index for collections
        /// </summary>
        public static void CreateIndexes(this IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<TaskReadDbContext>();

            //dbContext.GetCollection<Owner>().Indexes.CreateOneAsync(new CreateIndexModel<Owner>(Builders<Owner>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = nameof(Owner.Id), Unique = true }));
        }

    }
}
