using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using TaskoMask.Services.Monolith.Domain.DataModel.Entities;
using TaskoMask.Services.Monolith.Infrastructure.Data.Read.DbContext;
using System;

namespace TaskoMask.Services.Monolith.Infrastructure.Data.Read.DataProviders
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

                CreateIndexes(dbContext);
            }
        }



        /// <summary>
        /// Create index for collections
        /// </summary>
        private static void CreateIndexes(IReadDbContext dbContext)
        {

            #region Board Indexs

            dbContext.GetCollection<Board>().Indexes.CreateOneAsync(new CreateIndexModel<Board>(Builders<Board>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = nameof(Board.Id), Unique = true }));
            dbContext.GetCollection<Board>().Indexes.CreateOneAsync(new CreateIndexModel<Board>(Builders<Board>.IndexKeys.Ascending(x => x.ProjectId), new CreateIndexOptions() { Name = nameof(Board.ProjectId) }));


            #endregion

            #region Task Indexs

            dbContext.GetCollection<Task>().Indexes.CreateOneAsync(new CreateIndexModel<Task>(Builders<Task>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = nameof(Task.Id), Unique = true }));
            dbContext.GetCollection<Task>().Indexes.CreateOneAsync(new CreateIndexModel<Task>(Builders<Task>.IndexKeys.Ascending(x => x.CardId), new CreateIndexOptions() { Name = nameof(Task.CardId) }));


            #endregion

            #region Card Indexs

            dbContext.GetCollection<Card>().Indexes.CreateOneAsync(new CreateIndexModel<Card>(Builders<Card>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = nameof(Card.Id), Unique = true }));
            dbContext.GetCollection<Card>().Indexes.CreateOneAsync(new CreateIndexModel<Card>(Builders<Card>.IndexKeys.Ascending(x => x.BoardId), new CreateIndexOptions() { Name = nameof(Card.BoardId), Unique = false }));


            #endregion

            #region Activity Indexs

            dbContext.GetCollection<Activity>(nameof(ReadDbContext.Activities)).Indexes.CreateOneAsync(new CreateIndexModel<Activity>(Builders<Activity>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = nameof(Activity.Id), Unique = true }));
            dbContext.GetCollection<Activity>(nameof(ReadDbContext.Activities)).Indexes.CreateOneAsync(new CreateIndexModel<Activity>(Builders<Activity>.IndexKeys.Ascending(x => x.TaskId), new CreateIndexOptions() { Name = nameof(Activity.TaskId), Unique = false }));


            #endregion

            #region Comment Indexs

            dbContext.GetCollection<Comment>().Indexes.CreateOneAsync(new CreateIndexModel<Comment>(Builders<Comment>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = nameof(Comment.Id), Unique = true }));
            dbContext.GetCollection<Comment>().Indexes.CreateOneAsync(new CreateIndexModel<Comment>(Builders<Comment>.IndexKeys.Ascending(x => x.TaskId), new CreateIndexOptions() { Name = nameof(Comment.TaskId), Unique = false }));


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
