using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Linq;
using TaskoMask.Domain.ReadModel.Entities;
using TaskoMask.Infrastructure.Data.Common.DataProviders;
using TaskoMask.Infrastructure.Data.ReadModel.DbContext;
using TaskoMask.Infrastructure.Data.WriteModel.DbContext;

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
                var _writeDbContext = serviceScope.ServiceProvider.GetService<IWriteDbContext>();
                var _readDbContext = serviceScope.ServiceProvider.GetService<IReadDbContext>();
                var _owners = _readDbContext.GetCollection<Owner>();
                var _organizations = _readDbContext.GetCollection<Organization>();
                var _projects = _readDbContext.GetCollection<Project>();
                var _boards = _readDbContext.GetCollection<Board>();
                var _cards = _readDbContext.GetCollection<Card>();
                var _tasks = _readDbContext.GetCollection<Task>();

                //if database is empty
                if (!_owners.AsQueryable().Any())
                {
                    //TODO sync data with Write Side DB
                }

            }
        }

    }
}
