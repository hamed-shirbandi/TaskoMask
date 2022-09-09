using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Entities;
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




        /// <summary>
        /// 
        /// </summary>
        private static Operator GetAdminOperator(string userId, IConfiguration configuration)
        {
            return new Operator(userId)
            {
                DisplayName = configuration["SuperUser:DisplayName"],
                Email = configuration["SuperUser:Email"],
            };

        }

    }
}
