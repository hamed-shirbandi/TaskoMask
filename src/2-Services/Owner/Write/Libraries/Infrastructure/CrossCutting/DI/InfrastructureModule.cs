using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Infrastructure.Bus;
using TaskoMask.BuildingBlocks.Infrastructure.EventSourcing;
using TaskoMask.Services.Owner.Infrastructure.CrossCutting.Mapper;
using TaskoMask.Services.Owner.Infrastructure.CrossCutting.Mediator;

namespace TaskoMask.Services.Owner.Infrastructure.CrossCutting.DI
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
            services.AddMediator();
            services.AddMapper();
            services.AddInMemoryBus();
            services.AddRedisEventStoreService();
        }





        /// <summary>
        /// 
        /// </summary>
        public static void InitialDatabasesAndSeedEssentialData(this IServiceProvider serviceProvider)
        {
            //serviceProvider.InitialDatabase();
            //serviceProvider.SeedEssentialData();
        }

    }
}
