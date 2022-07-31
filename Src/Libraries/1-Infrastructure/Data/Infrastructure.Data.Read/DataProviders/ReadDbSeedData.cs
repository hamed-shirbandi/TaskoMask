using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using TaskoMask.Domain.DataModel.Entities;
using TaskoMask.Infrastructure.Data.Read.DbContext;

namespace TaskoMask.Infrastructure.Data.Read.DataProviders
{

    /// <summary>
    /// 
    /// </summary>
    public static class ReadDbSeedData
    {

        /// <summary>
        /// 
        /// </summary>
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var _readDbContext = serviceScope.ServiceProvider.GetService<IReadDbContext>();
                var _owners = _readDbContext.GetCollection<Owner>();

                if (!_owners.AsQueryable().Any())
                {
                    //Here you can seed your primary data
                }

            }
        }

    }
}
