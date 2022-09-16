using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.DbContext;

namespace TaskoMask.Services.Monolith.Infrastructure.Data.Write.DataProviders
{

    /// <summary>
    /// 
    /// </summary>
    public static class WriteDbSeedData
    {


        /// <summary>
        /// Seed the necessary data that system needs
        /// </summary>
        public static void SeedEssentialData(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var _dbContext = serviceScope.ServiceProvider.GetService<IWriteDbContext>();
                var _configuration = serviceScope.ServiceProvider.GetService<IConfiguration>();

               // var _operators = _dbContext.GetCollection<Operator>();
               // seed data here ...
            }
        }
    }
}
