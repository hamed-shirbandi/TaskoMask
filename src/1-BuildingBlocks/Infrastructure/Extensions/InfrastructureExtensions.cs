using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskoMask.BuildingBlocks.Infrastructure.Bus;
using TaskoMask.BuildingBlocks.Infrastructure.EventSourcing;

namespace TaskoMask.BuildingBlocks.Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static void AddBuildingBlocksInfrastructure(this IServiceCollection services, IConfiguration configuration, Type consumerAssemblyMarkerType, params Type[] handlerAssemblyMarkerTypes)
        {
            services.AddInMemoryBus(handlerAssemblyMarkerTypes);
            services.AddMessageBus(configuration, consumerAssemblyMarkerType);
            services.AddRedisEventStoreService();
        }
    }
}
