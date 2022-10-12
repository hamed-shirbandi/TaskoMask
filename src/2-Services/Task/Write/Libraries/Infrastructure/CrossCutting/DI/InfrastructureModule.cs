using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Infrastructure.Bus;
using TaskoMask.BuildingBlocks.Infrastructure.EntityFramework;
using TaskoMask.BuildingBlocks.Infrastructure.EventSourcing;
using TaskoMask.Services.Task.Infrastructure.Data.DbContext;

namespace TaskoMask.Services.Task.Infrastructure.CrossCutting.DI
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
            services.AddDbContext(options =>
            {
                configuration.GetSection("EntityFramework").Bind(options);
            });
        }



        /// <summary>
        /// 
        /// </summary>
        public static void AddDbContext(this IServiceCollection services, Action<EFCoreDbOptions> setupAction)
        {
            services.Configure(setupAction);
            services.AddDbContext<TaskWriteDbContext>();
        }



        /// <summary>
        /// 
        /// </summary>
        public static void InitialDatabasesAndSeedEssentialData(this IServiceProvider serviceProvider)
        {
            serviceProvider.InitialDatabase<TaskWriteDbContext>();
            // no need for seeding any data
        }

    }
}
