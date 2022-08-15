using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Domain.Services;

namespace TaskoMask.BuildingBlocks.Infrastructure.EventSourcing
{
    public static class EventStoreExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddRedisEventStoreService(this IServiceCollection services)
        {
            return services.AddScoped<IEventStoreService, RedisEventStoreService>();
        }
    }
}
