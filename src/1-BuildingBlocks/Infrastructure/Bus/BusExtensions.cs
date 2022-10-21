using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Application.Bus;

namespace TaskoMask.BuildingBlocks.Infrastructure.Bus
{
    public static class BusExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static void AddBus(this IServiceCollection services)
        {
            services.AddInMemoryBus();
            services.AddMessageBus();
        }


        /// <summary>
        /// 
        /// </summary>
        public static void AddInMemoryBus(this IServiceCollection services)
        {
            services.AddScoped<IInMemoryBus, InMemoryBus>();
        }


        /// <summary>
        /// 
        /// </summary>
        public static void AddMessageBus(this IServiceCollection services)
        {
            services.AddScoped<IMessageBus, MessageBus>();
        }
    }
}
