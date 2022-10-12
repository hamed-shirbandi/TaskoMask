using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System;
using TaskoMask.BuildingBlocks.Domain.Data;

namespace TaskoMask.BuildingBlocks.Infrastructure.MongoDB
{
    /// <summary>
    /// 
    /// </summary>
    public static class MongoDbExtensions
    {


        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddMongoDbBaseRepository(this IServiceCollection services)
        {
            return services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        }



        /// <summary>
        /// Drop database
        /// </summary>
        public static void DropDatabase<TContext>(IServiceProvider serviceProvider) where TContext : MongoDbContext
        {
            using var serviceScope = serviceProvider.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<TContext>();

            dbContext.DropDatabase();
        }



        /// <summary>
        /// 
        /// </summary>
        public static bool Has<TModel>(this IList<string> collections, string name = "")
        {
            var collection = name;
            if (string.IsNullOrEmpty(collection))
            {
                collection = typeof(TModel).Name;

                if (!collection.EndsWith("s")) collection += "s";
            }

            return collections.Contains(collection);
        }


    }
}
