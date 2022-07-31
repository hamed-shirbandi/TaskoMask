using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using TaskoMask.Infrastructure.Data.Core.Extensions;
using System;
using TaskoMask.Infrastructure.Data.Core.DbContext;
using TaskoMask.Domain.DataModel.Entities;
using TaskoMask.Infrastructure.Data.ReadModel.DbContext;

namespace TaskoMask.Infrastructure.Data.ReadModel.DataProviders
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

                CreateCollections(dbContext);

                CreateIndexes(dbContext);
            }
        }



        /// <summary>
        /// Ensure collections created
        /// </summary>
        private static void CreateCollections(IReadDbContext dbContext)
        {
            var collections = dbContext.Collections();

            if (!collections.Has<Owner>())
                dbContext.CreateCollection<Owner>();

            if (!collections.Has<Organization>())
                dbContext.CreateCollection<Organization>();


            if (!collections.Has<Project>())
                dbContext.CreateCollection<Project>();

            if (!collections.Has<Board>())
                dbContext.CreateCollection<Board>();

            if (!collections.Has<Card>())
                dbContext.CreateCollection<Card>();

            if (!collections.Has<Domain.DataModel.Entities.Task>())
                dbContext.CreateCollection<Domain.DataModel.Entities.Task>();
       
            if (!collections.Has<Member>())
                dbContext.CreateCollection<Member>();

            if (!collections.Has<Activity>("Activities"))
                dbContext.CreateCollection<Activity>("Activities");

            if (!collections.Has<Comment>())
                dbContext.CreateCollection<Comment>();

        }



        /// <summary>
        /// Create index for collections
        /// </summary>
        private static void CreateIndexes(IReadDbContext dbContext)
        {
            #region Owner Indexs

            dbContext.GetCollection<Owner>().Indexes.CreateOneAsync(new CreateIndexModel<Owner>(Builders<Owner>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = "Id", Unique = true }));
            dbContext.GetCollection<Owner>().Indexes.CreateOneAsync(new CreateIndexModel<Owner>(Builders<Owner>.IndexKeys.Ascending(x => x.Email), new CreateIndexOptions() { Name = "Email" }));
            dbContext.GetCollection<Owner>().Indexes.CreateOneAsync(new CreateIndexModel<Owner>(Builders<Owner>.IndexKeys.Ascending(x => x.DisplayName), new CreateIndexOptions() { Name = "DisplayName" }));


            #endregion

            #region Organization Indexs

            dbContext.GetCollection<Organization>().Indexes.CreateOneAsync(new CreateIndexModel<Organization>(Builders<Organization>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = "Id", Unique = true }));
            dbContext.GetCollection<Organization>().Indexes.CreateOneAsync(new CreateIndexModel<Organization>(Builders<Organization>.IndexKeys.Ascending(x => x.OwnerId), new CreateIndexOptions() { Name = "OwnerId" }));


            #endregion

            #region Project Indexs

            dbContext.GetCollection<Project>().Indexes.CreateOneAsync(new CreateIndexModel<Project>(Builders<Project>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = "Id", Unique = true }));
            dbContext.GetCollection<Project>().Indexes.CreateOneAsync(new CreateIndexModel<Project>(Builders<Project>.IndexKeys.Ascending(x => x.OrganizationId), new CreateIndexOptions() { Name = "OrganizationId" }));


            #endregion

            #region Board Indexs

            dbContext.GetCollection<Board>().Indexes.CreateOneAsync(new CreateIndexModel<Board>(Builders<Board>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = "Id", Unique = true }));
            dbContext.GetCollection<Board>().Indexes.CreateOneAsync(new CreateIndexModel<Board>(Builders<Board>.IndexKeys.Ascending(x => x.ProjectId), new CreateIndexOptions() { Name = "ProjectId" }));


            #endregion

            #region Task Indexs

            dbContext.GetCollection<Domain.DataModel.Entities.Task>().Indexes.CreateOneAsync(new CreateIndexModel<Domain.DataModel.Entities.Task>(Builders<Domain.DataModel.Entities.Task>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = "Id", Unique = true }));
            dbContext.GetCollection<Domain.DataModel.Entities.Task>().Indexes.CreateOneAsync(new CreateIndexModel<Domain.DataModel.Entities.Task>(Builders<Domain.DataModel.Entities.Task>.IndexKeys.Ascending(x => x.CardId), new CreateIndexOptions() { Name = "CardId" }));


            #endregion

            #region Card Indexs

            dbContext.GetCollection<Card>().Indexes.CreateOneAsync(new CreateIndexModel<Card>(Builders<Card>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = "Id", Unique = true }));


            #endregion

            #region Activity Indexs

            dbContext.GetCollection<Activity>("Activities").Indexes.CreateOneAsync(new CreateIndexModel<Activity>(Builders<Activity>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = "Id", Unique = true }));


            #endregion

            #region Comment Indexs

            dbContext.GetCollection<Comment>().Indexes.CreateOneAsync(new CreateIndexModel<Comment>(Builders<Comment>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = "Id", Unique = true }));


            #endregion
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
