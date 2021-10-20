using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using TaskoMask.Domain.Administration.Entities;
using TaskoMask.Domain.Core.Extensions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.TaskManagement.Entities;
using TaskoMask.Domain.Team.Entities;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.DataProviders
{

    /// <summary>
    /// 
    /// </summary>
    public static class DbInitialization
    {

        /// <summary>
        /// initial db and create collections and set indexes
        /// </summary>
        public static void InitialMongoDb(this IServiceScopeFactory scopeFactory)
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

            if (!collections.Has<Card>())
                dbContext.CreateCollection<Card>();

            if (!collections.Has<Task>())
                dbContext.CreateCollection<Task>();

            if (!collections.Has<Organization>())
                dbContext.CreateCollection<Organization>();

            if (!collections.Has<Project>())
                dbContext.CreateCollection<Project>();

            if (!collections.Has<Member>())
                dbContext.CreateCollection<Member>();


            if (!collections.Has<Operator>())
                dbContext.CreateCollection<Operator>();

        }



        /// <summary>
        /// Create index for collections
        /// </summary>
        private static void CreateIndexes(IMongoDbContext dbContext)
        {
            #region Task Indexs

            dbContext.GetCollection<Task>().Indexes.CreateOneAsync(new CreateIndexModel<Task>(Builders<Task>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = "Id", Unique = true }));
            dbContext.GetCollection<Task>().Indexes.CreateOneAsync(new CreateIndexModel<Task>(Builders<Task>.IndexKeys.Ascending(x => x.CardId), new CreateIndexOptions() { Name = "CardId" }));


            #endregion

            #region Card Indexs

            dbContext.GetCollection<Card>().Indexes.CreateOneAsync(new CreateIndexModel<Card>(Builders<Card>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = "Id", Unique = true }));
            dbContext.GetCollection<Card>().Indexes.CreateOneAsync(new CreateIndexModel<Card>(Builders<Card>.IndexKeys.Ascending(x => x.BoardId), new CreateIndexOptions() { Name = "BoardId" }));


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
            dbContext.GetCollection<Organization>().Indexes.CreateOneAsync(new CreateIndexModel<Organization>(Builders<Organization>.IndexKeys.Ascending(x => x.OwnerMemberId), new CreateIndexOptions() { Name = "OwnerMemberId" }));


            #endregion

            #region Member Indexs

            dbContext.GetCollection<Member>().Indexes.CreateOneAsync(new CreateIndexModel<Member>(Builders<Member>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = "Id", Unique = true }));
            dbContext.GetCollection<Member>().Indexes.CreateOneAsync(new CreateIndexModel<Member>(Builders<Member>.IndexKeys.Ascending(x => x.UserName), new CreateIndexOptions() { Name = "UserName", Unique = true }));
            dbContext.GetCollection<Member>().Indexes.CreateOneAsync(new CreateIndexModel<Member>(Builders<Member>.IndexKeys.Ascending(x => x.Email), new CreateIndexOptions() { Name = "Email" }));
            dbContext.GetCollection<Member>().Indexes.CreateOneAsync(new CreateIndexModel<Member>(Builders<Member>.IndexKeys.Ascending(x => x.PhoneNumber), new CreateIndexOptions() { Name = "PhoneNumber", Unique = false }));
            dbContext.GetCollection<Member>().Indexes.CreateOneAsync(new CreateIndexModel<Member>(Builders<Member>.IndexKeys.Ascending(x => x.DisplayName), new CreateIndexOptions() { Name = "DisplayName" }));


            #endregion

            #region Operator Indexs

            dbContext.GetCollection<Operator>().Indexes.CreateOneAsync(new CreateIndexModel<Operator>(Builders<Operator>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = "Id", Unique = true }));
            dbContext.GetCollection<Operator>().Indexes.CreateOneAsync(new CreateIndexModel<Operator>(Builders<Operator>.IndexKeys.Ascending(x => x.UserName), new CreateIndexOptions() { Name = "UserName", Unique = true }));
            dbContext.GetCollection<Operator>().Indexes.CreateOneAsync(new CreateIndexModel<Operator>(Builders<Operator>.IndexKeys.Ascending(x => x.Email), new CreateIndexOptions() { Name = "Email" }));
            dbContext.GetCollection<Operator>().Indexes.CreateOneAsync(new CreateIndexModel<Operator>(Builders<Operator>.IndexKeys.Ascending(x => x.PhoneNumber), new CreateIndexOptions() { Name = "PhoneNumber", Unique = false }));
            dbContext.GetCollection<Operator>().Indexes.CreateOneAsync(new CreateIndexModel<Operator>(Builders<Operator>.IndexKeys.Ascending(x => x.DisplayName), new CreateIndexOptions() { Name = "DisplayName" }));


            #endregion

        }

    }
}
