using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Domain.Data;
using TaskoMask.BuildingBlocks.Application.Bus;

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
        public static IServiceCollection AddMongoDBBaseRepository(this IServiceCollection services)
        {
            return services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

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
