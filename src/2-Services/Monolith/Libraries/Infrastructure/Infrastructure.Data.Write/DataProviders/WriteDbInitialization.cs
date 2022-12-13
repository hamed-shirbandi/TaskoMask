using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Entities;
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
            #region Board Indexs

            dbContext.GetCollection<Board>().Indexes.CreateOneAsync(new CreateIndexModel<Board>(Builders<Board>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = nameof(Board.Id), Unique = true }));
            dbContext.GetCollection<Board>().Indexes.CreateOneAsync(new CreateIndexModel<Board>(Builders<Board>.IndexKeys.Ascending(x => x.ProjectId.Value), new CreateIndexOptions() { Name = nameof(Board.ProjectId) }));


            #endregion

            #region Task Indexs

            dbContext.GetCollection<Task>().Indexes.CreateOneAsync(new CreateIndexModel<Task>(Builders<Task>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = nameof(Task.Id), Unique = true }));
            dbContext.GetCollection<Task>().Indexes.CreateOneAsync(new CreateIndexModel<Task>(Builders<Task>.IndexKeys.Ascending(x => x.CardId.Value), new CreateIndexOptions() { Name = nameof(Task.CardId) }));


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
