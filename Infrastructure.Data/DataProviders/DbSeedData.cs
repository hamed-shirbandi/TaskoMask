using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System.Linq;
using TaskoMask.Domain.Core.Services;
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
                var _encryptionService = serviceScope.ServiceProvider.GetService<IEncryptionService>();
                var _users = _dbContext.GetCollection<User>();

                if (!_users.OfType<Operator>().AsQueryable().Any())
                {
                    var user = new Operator(_configuration["SuperUser:DisplayName"], _configuration["SuperUser:Email"], _configuration["SuperUser:Email"], _configuration["SuperUser:Password"], _encryptionService);
                    _users.OfType<Operator>().InsertOne(user);
                }

            }
        }

    }
}
