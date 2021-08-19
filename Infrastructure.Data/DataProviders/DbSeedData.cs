using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System.Linq;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Entities;

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
                var configuration = serviceScope.ServiceProvider.GetService<IConfiguration>();
                //TODO seed some data
            }
        }

    }
}
