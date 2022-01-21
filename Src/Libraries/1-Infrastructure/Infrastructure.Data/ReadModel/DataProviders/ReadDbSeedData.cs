using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Linq;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.ReadModel.Entities;
using TaskoMask.Infrastructure.Data.Common.DataProviders;
using TaskoMask.Infrastructure.Data.Common.DbContext;
using TaskoMask.Infrastructure.Data.ReadModel.DbContext;

namespace TaskoMask.Infrastructure.Data.ReadModel.DataProviders
{

    /// <summary>
    /// 
    /// </summary>
    public static class ReadDbSeedData
    {

        /// <summary>
        /// 
        /// </summary>
        public static void SeedAdminPanelTempData(this IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var _dbContext = serviceScope.ServiceProvider.GetService<IReadDbContext>();

                var _owners = _dbContext.GetCollection<Owner>();
                var _organizations = _dbContext.GetCollection<Organization>();
                var _projects = _dbContext.GetCollection<Project>();
                var _boards = _dbContext.GetCollection<Board>();
                var _cards = _dbContext.GetCollection<Card>();
                var _tasks = _dbContext.GetCollection<Task>();

                //if read database is empty
                if (!_owners.AsQueryable().Any())
                {
                    var users = WriteDataGenerator.GenerateUser();
                    var owners = ReadDataGenerator.GenerateOwner(users);
                    _owners.InsertMany(owners);


                    var organizations = ReadDataGenerator.GenerateOrganization(owners);
                    _organizations.InsertMany(organizations);

                    var projects = ReadDataGenerator.GenerateProject(organizations);
                    _projects.InsertMany(projects);

                    var boards = ReadDataGenerator.GenerateBoard(projects);
                    _boards.InsertMany(boards);

                    var cards = ReadDataGenerator.GenerateCard(boards);
                    _cards.InsertMany(cards);

                    var tasks = ReadDataGenerator.GenerateTasks(cards);
                    _tasks.InsertMany(tasks);
                }

            }
        }

    }
}
