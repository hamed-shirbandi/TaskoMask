using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using TaskoMask.Domain.Core.Extensions;
using TaskoMask.Domain.Models;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.DataProviders
{
    public static class DbInitialization
    {

        /// <summary>
        /// initial db and create collections and set indexes
        /// </summary>
        public static void InitialDatabase(this IServiceScopeFactory scopeFactory)
        {
            using (var serviceScope = scopeFactory.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<IMongoDbContext>();

                CreateCollections(dbContext);

                CreateIndexes(dbContext);
            }
        }



        /// <summary>
        /// Ensure collections created
        /// </summary>
        private static void CreateCollections(IMongoDbContext dbContext)
        {
            var collections = dbContext.Collections();

            if (!collections.Has<Board>())
                dbContext.CreateCollection<Board>();

            if (!collections.Has<Task>())
                dbContext.CreateCollection<Task>();

            if (!collections.Has<Organization>())
                dbContext.CreateCollection<Organization>();

            if (!collections.Has<Project>())
                dbContext.CreateCollection<Project>();
        }



        /// <summary>
        /// Create index for collections
        /// </summary>
        private static void CreateIndexes(IMongoDbContext dbContext)
        {
            #region Task Indexs

            dbContext.GetCollection<Task>().Indexes.CreateOneAsync(new CreateIndexModel<Task>(Builders<Task>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = "Id", Unique = true }));
            dbContext.GetCollection<Task>().Indexes.CreateOneAsync(new CreateIndexModel<Task>(Builders<Task>.IndexKeys.Ascending(x => x.BoardId), new CreateIndexOptions() { Name = "BoardId" }));


            #endregion

            #region Board Indexs

            dbContext.GetCollection<Board>().Indexes.CreateOneAsync(new CreateIndexModel<Board>(Builders<Board>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = "Id", Unique = true }));
            dbContext.GetCollection<Board>().Indexes.CreateOneAsync(new CreateIndexModel<Board>(Builders<Board>.IndexKeys.Ascending(x => x.ProjectId), new CreateIndexOptions() { Name = "ProjectId" }));


            #endregion

            #region Project Indexs

            dbContext.GetCollection<Project>().Indexes.CreateOneAsync(new CreateIndexModel<Project>(Builders<Project>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = "Id", Unique = true }));
            dbContext.GetCollection<Project>().Indexes.CreateOneAsync(new CreateIndexModel<Project>(Builders<Project>.IndexKeys.Ascending(x => x.OrganizationId), new CreateIndexOptions() { Name = "OrganizationId" }));


            #endregion

            #region Organization Indexs

            dbContext.GetCollection<Organization>().Indexes.CreateOneAsync(new CreateIndexModel<Organization>(Builders<Organization>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = "Id", Unique = true }));
            dbContext.GetCollection<Organization>().Indexes.CreateOneAsync(new CreateIndexModel<Organization>(Builders<Organization>.IndexKeys.Ascending(x => x.UserId), new CreateIndexOptions() { Name = "UserId" }));


            #endregion
        }

    }
}
