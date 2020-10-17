using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskoMask.Domain.Core.Enums;
using TaskoMask.Domain.Models;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.DataProviders
{
    public static class DbContextSeedData
    {

        public static void SeedDatabase(this IServiceScopeFactory scopeFactory)
        {
            using (var serviceScope = scopeFactory.CreateScope())
            {
                string adminRoleId = string.Empty;
                var dbContext = serviceScope.ServiceProvider.GetService<IMongoDbContext>();
                var _tasks = dbContext.GetCollection<Task>();

                //TODO: seed user,organization,project,board

                #region Tasks

                if (!_tasks.AsQueryable().Any())
                {
                    //var role = new Task
                    //{
                    //    Title = "test title",
                    //    Description = "test Description",
                    //    State=TaskState.ToDo,
                    //    BoardId="GET FROM SEEDED BOARD",
                    //};
                    //_tasks.InsertOne(role);
                }



                #endregion

            }
        }
    }
}
