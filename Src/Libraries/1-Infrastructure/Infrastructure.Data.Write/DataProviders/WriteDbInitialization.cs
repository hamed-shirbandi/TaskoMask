using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using TaskoMask.Domain.DomainModel.Membership.Entities;
using TaskoMask.Infrastructure.Data.Core.Extensions;
using System;
using TaskoMask.Domain.DomainModel.Workspace.Boards.Entities;
using TaskoMask.Domain.DomainModel.Workspace.Tasks.Entities;
using TaskoMask.Domain.DomainModel.Workspace.Owners.Entities;
using TaskoMask.Domain.DomainModel.Authorization.Entities;
using TaskoMask.Infrastructure.Data.Core.DbContext;
using TaskoMask.Infrastructure.Data.WriteModel.DbContext;

namespace TaskoMask.Infrastructure.Data.WriteModel.DataProviders
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

                CreateCollections(dbContext);

                CreateIndexes(dbContext);
            }
        }



        /// <summary>
        /// Ensure collections created
        /// </summary>
        private static void CreateCollections(IWriteDbContext dbContext)
        {
            var collections = dbContext.Collections();

            if (!collections.Has<Owner>())
                dbContext.CreateCollection<Owner>();

            if (!collections.Has<Board>())
                dbContext.CreateCollection<Board>();

            if (!collections.Has<Task>())
                dbContext.CreateCollection<Task>();


            if (!collections.Has<User>())
                dbContext.CreateCollection<User>();

            if (!collections.Has<Operator>())
                dbContext.CreateCollection<Operator>();

            if (!collections.Has<Role>())
                dbContext.CreateCollection<Role>();

            if (!collections.Has<Permission>())
                dbContext.CreateCollection<Permission>();



        }



        /// <summary>
        /// Create index for collections
        /// </summary>
        private static void CreateIndexes(IWriteDbContext dbContext)
        {
            #region Owner Indexs

            dbContext.GetCollection<Owner>().Indexes.CreateOneAsync(new CreateIndexModel<Owner>(Builders<Owner>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = "Id", Unique = true }));
            dbContext.GetCollection<Owner>().Indexes.CreateOneAsync(new CreateIndexModel<Owner>(Builders<Owner>.IndexKeys.Ascending(x => x.Email.Value), new CreateIndexOptions() { Name = "Email" }));
            dbContext.GetCollection<Owner>().Indexes.CreateOneAsync(new CreateIndexModel<Owner>(Builders<Owner>.IndexKeys.Ascending(x => x.DisplayName.Value), new CreateIndexOptions() { Name = "DisplayName" }));


            #endregion

            #region Board Indexs

            dbContext.GetCollection<Board>().Indexes.CreateOneAsync(new CreateIndexModel<Board>(Builders<Board>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = "Id", Unique = true }));
            dbContext.GetCollection<Board>().Indexes.CreateOneAsync(new CreateIndexModel<Board>(Builders<Board>.IndexKeys.Ascending(x => x.ProjectId), new CreateIndexOptions() { Name = "ProjectId" }));


            #endregion

            #region Task Indexs

            dbContext.GetCollection<Task>().Indexes.CreateOneAsync(new CreateIndexModel<Task>(Builders<Task>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = "Id", Unique = true }));
            dbContext.GetCollection<Task>().Indexes.CreateOneAsync(new CreateIndexModel<Task>(Builders<Task>.IndexKeys.Ascending(x => x.CardId), new CreateIndexOptions() { Name = "CardId" }));


            #endregion

            #region User Indexs

            dbContext.GetCollection<User>().Indexes.CreateOneAsync(new CreateIndexModel<User>(Builders<User>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = "Id", Unique = true }));
            dbContext.GetCollection<User>().Indexes.CreateOneAsync(new CreateIndexModel<User>(Builders<User>.IndexKeys.Ascending(x => x.UserName), new CreateIndexOptions() { Name = "UserName", Unique = true }));


            #endregion

            #region Operator Indexs

            dbContext.GetCollection<Operator>().Indexes.CreateOneAsync(new CreateIndexModel<Operator>(Builders<Operator>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = "Id", Unique = true }));
            dbContext.GetCollection<Operator>().Indexes.CreateOneAsync(new CreateIndexModel<Operator>(Builders<Operator>.IndexKeys.Ascending(x => x.Email), new CreateIndexOptions() { Name = "Email" }));
            dbContext.GetCollection<Operator>().Indexes.CreateOneAsync(new CreateIndexModel<Operator>(Builders<Operator>.IndexKeys.Ascending(x => x.DisplayName), new CreateIndexOptions() { Name = "DisplayName" }));


            #endregion

            #region Role Indexs

            dbContext.GetCollection<Role>().Indexes.CreateOneAsync(new CreateIndexModel<Role>(Builders<Role>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = "Id", Unique = true }));

            #endregion

            #region Permission Indexs

            dbContext.GetCollection<Permission>().Indexes.CreateOneAsync(new CreateIndexModel<Permission>(Builders<Permission>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = "Id", Unique = true }));

            #endregion

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
