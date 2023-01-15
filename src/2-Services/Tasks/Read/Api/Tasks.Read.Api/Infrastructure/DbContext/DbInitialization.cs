using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using TaskoMask.Services.Tasks.Read.Api.Domain;

namespace TaskoMask.Services.Tasks.Read.Api.Infrastructure.DbContext
{

    /// <summary>
    /// 
    /// </summary>
    public static class DbInitialization
    {


        /// <summary>
        /// 
        /// </summary>
        public static void InitialDatabase(this IServiceProvider serviceProvider)
        {
            serviceProvider.CreateIndexes();
        }



        /// <summary>
        /// Drop database
        /// </summary>
        public static void DropDatabase(this IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.CreateScope();

            var dbContext = serviceScope.ServiceProvider.GetService<TaskReadDbContext>();

            dbContext.DropDatabase();
        }



        /// <summary>
        /// Create index for collections
        /// </summary>
        private static void CreateIndexes(this IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<TaskReadDbContext>();

            #region Task Indexs

            dbContext.Tasks.Indexes.CreateOneAsync(new CreateIndexModel<Domain.Task>(Builders<Domain.Task>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = nameof(Domain.Task.Id), Unique = true }));
            dbContext.Tasks.Indexes.CreateOneAsync(new CreateIndexModel<Domain.Task>(Builders<Domain.Task>.IndexKeys.Ascending(x => x.CardId), new CreateIndexOptions() { Name = nameof(Domain.Task.CardId) }));


            #endregion


            #region Activity Indexs

            dbContext.Activities.Indexes.CreateOneAsync(new CreateIndexModel<Activity>(Builders<Activity>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = nameof(Activity.Id), Unique = true }));
            dbContext.Activities.Indexes.CreateOneAsync(new CreateIndexModel<Activity>(Builders<Activity>.IndexKeys.Ascending(x => x.TaskId), new CreateIndexOptions() { Name = nameof(Activity.TaskId), Unique = false }));


            #endregion

            #region Comment Indexs

            dbContext.Comments.Indexes.CreateOneAsync(new CreateIndexModel<Comment>(Builders<Comment>.IndexKeys.Ascending(x => x.Id), new CreateIndexOptions() { Name = nameof(Comment.Id), Unique = true }));
            dbContext.Comments.Indexes.CreateOneAsync(new CreateIndexModel<Comment>(Builders<Comment>.IndexKeys.Ascending(x => x.TaskId), new CreateIndexOptions() { Name = nameof(Comment.TaskId), Unique = false }));


            #endregion
        }

    }
}
