using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Entities;
using System;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Entities;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.DbContext;

namespace TaskoMask.Services.Monolith.Infrastructure.Data.Write.DataProviders
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

                CreateIndexes(dbContext);
            }
        }




        /// <summary>
        /// Create index for collections
        /// </summary>
        private static void CreateIndexes(IWriteDbContext dbContext)
        {
            #region Owner Indexs

            dbContext.GetCollection<Owner>().Indexes.CreateOneAsync(new CreateIndexModel<Owner>(Builders<Owner>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = nameof(Owner.Id), Unique = true }));
            dbContext.GetCollection<Owner>().Indexes.CreateOneAsync(new CreateIndexModel<Owner>(Builders<Owner>.IndexKeys.Ascending(x => x.Email.Value), new CreateIndexOptions() { Name = nameof(Owner.Email) }));
            dbContext.GetCollection<Owner>().Indexes.CreateOneAsync(new CreateIndexModel<Owner>(Builders<Owner>.IndexKeys.Ascending(x => x.DisplayName.Value), new CreateIndexOptions() { Name = nameof(Owner.DisplayName) }));


            #endregion

            #region Board Indexs

            dbContext.GetCollection<Board>().Indexes.CreateOneAsync(new CreateIndexModel<Board>(Builders<Board>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = nameof(Board.Id), Unique = true }));
            dbContext.GetCollection<Board>().Indexes.CreateOneAsync(new CreateIndexModel<Board>(Builders<Board>.IndexKeys.Ascending(x => x.ProjectId.Value), new CreateIndexOptions() { Name = nameof(Board.ProjectId) }));


            #endregion

            #region Task Indexs

            dbContext.GetCollection<Task>().Indexes.CreateOneAsync(new CreateIndexModel<Task>(Builders<Task>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = nameof(Task.Id), Unique = true }));
            dbContext.GetCollection<Task>().Indexes.CreateOneAsync(new CreateIndexModel<Task>(Builders<Task>.IndexKeys.Ascending(x => x.CardId.Value), new CreateIndexOptions() { Name = nameof(Task.CardId) }));


            #endregion

            #region Operator Indexs

            dbContext.GetCollection<Operator>().Indexes.CreateOneAsync(new CreateIndexModel<Operator>(Builders<Operator>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = nameof(Operator.Id), Unique = true }));
            dbContext.GetCollection<Operator>().Indexes.CreateOneAsync(new CreateIndexModel<Operator>(Builders<Operator>.IndexKeys.Ascending(x => x.Email), new CreateIndexOptions() { Name = nameof(Operator.Email) }));
            dbContext.GetCollection<Operator>().Indexes.CreateOneAsync(new CreateIndexModel<Operator>(Builders<Operator>.IndexKeys.Ascending(x => x.DisplayName), new CreateIndexOptions() { Name = nameof(Operator.DisplayName) }));


            #endregion

            #region Role Indexs

            dbContext.GetCollection<Role>().Indexes.CreateOneAsync(new CreateIndexModel<Role>(Builders<Role>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = nameof(Role.Id), Unique = true }));
            dbContext.GetCollection<Role>().Indexes.CreateOneAsync(new CreateIndexModel<Role>(Builders<Role>.IndexKeys.Ascending(x => x.Name), new CreateIndexOptions() { Name = nameof(Role.Name), Unique = false }));

            #endregion

            #region Permission Indexs

            dbContext.GetCollection<Permission>().Indexes.CreateOneAsync(new CreateIndexModel<Permission>(Builders<Permission>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = nameof(Permission.Id), Unique = true }));
            dbContext.GetCollection<Permission>().Indexes.CreateOneAsync(new CreateIndexModel<Permission>(Builders<Permission>.IndexKeys.Ascending(x => x.SystemName), new CreateIndexOptions() { Name = nameof(Permission.SystemName), Unique = false }));

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
