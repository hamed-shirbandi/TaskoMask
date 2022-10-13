using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Infrastructure.Bus;
using TaskoMask.BuildingBlocks.Infrastructure.EventSourcing;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using TaskoMask.Services.Boards.Write.Infrastructure.Data.DbContext;

namespace TaskoMask.Services.Boards.Write.Infrastructure.CrossCutting.DI
{

    /// <summary>
    /// 
    /// </summary>
    public static class InfrastructureModule
    {


        /// <summary>
        /// 
        /// </summary>
        public static void AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInMemoryBus();
            services.AddRedisEventStoreService();
            services.AddMongoDbContext(configuration);
        }



        /// <summary>
        /// 
        /// </summary>
        private static void AddMongoDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetSection("MongoDB");
            services.AddScoped<BoardWriteDbContext>().AddOptions<MongoDbOptions>().Bind(options);
        }

    }
}
