using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Infrastructure.Bus;
using TaskoMask.BuildingBlocks.Infrastructure.EventSourcing;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;

namespace TaskoMask.BuildingBlocks.Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddBuildingBlocksInfrastructureServices(this IServiceCollection services)
        {

            services.AddInMemoryBus();
            services.AddRedisEventStoreService();

            return services;
        }
    }
}
