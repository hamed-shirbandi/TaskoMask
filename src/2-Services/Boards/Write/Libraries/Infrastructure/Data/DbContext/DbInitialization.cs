using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using TaskoMask.Services.Boards.Write.Domain.Entities;

namespace TaskoMask.Services.Boards.Write.Infrastructure.Data.DbContext
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

            var dbContext = serviceScope.ServiceProvider.GetService<BoardWriteDbContext>();

            dbContext.DropDatabase();
        }



        /// <summary>
        /// Seed the necessary data that system needs
        /// </summary>
        private static void SeedEssentialData(this IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<BoardWriteDbContext>();

            // dbContext.Boards.InsertOneAsync(x)

        }



        /// <summary>
        /// Create index for collections
        /// </summary>
        private static void CreateIndexes(this IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<BoardWriteDbContext>();

            dbContext.Boards.Indexes.CreateOneAsync(new CreateIndexModel<Board>(Builders<Board>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = nameof(Board.Id), Unique = true }));
            dbContext.Boards.Indexes.CreateOneAsync(new CreateIndexModel<Board>(Builders<Board>.IndexKeys.Ascending(x => x.ProjectId.Value), new CreateIndexOptions() { Name = nameof(Board.ProjectId) }));

        }

    }
}
