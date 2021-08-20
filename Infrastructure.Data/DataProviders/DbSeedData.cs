using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System.Linq;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Entities;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.DataProviders
{

    /// <summary>
    /// 
    /// </summary>
    public static class DbSeedData
    {


        /// <summary>
        /// 
        /// </summary>
        public static void MongoDbSeedData(this IServiceScopeFactory scopeFactory)
        {
            using (var serviceScope = scopeFactory.CreateScope())
            {
                var _dbContext = serviceScope.ServiceProvider.GetService<IMainDbContext>();
                var _configuration = serviceScope.ServiceProvider.GetService<IConfiguration>();
                var _users = _dbContext.GetCollection<User>();

                if (!_users.AsQueryable().Any())
                {
                    var user = new User(_configuration["SuperUser:DisplayName"], _configuration["SuperUser:Email"],_configuration["SuperUser:Email"]);
                    _users.InsertOne(user);
                }

            }
        }

    }
}
