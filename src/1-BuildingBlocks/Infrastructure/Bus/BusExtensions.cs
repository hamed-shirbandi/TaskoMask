using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Infrastructure.MassTransit;

namespace TaskoMask.BuildingBlocks.Infrastructure.Bus
{
    public static class BusExtensions
    {


        /// <summary>
        /// 
        /// </summary>
        public static void AddInMemoryBus(this IServiceCollection services, Type handlerAssemblyMarkerType)
        {
            //Load all handlers in given assemblies
            services.AddMediatR(handlerAssemblyMarkerType);

            services.AddScoped<IInMemoryBus, InMemoryBus>();
        }


        /// <summary>
        /// 
        /// </summary>
        public static void AddMessageBus(this IServiceCollection services, IConfiguration configuration, Type consumerAssemblyMarkerType)
        {
            services.AddMassTransitWithRabbitMqTransport(configuration, consumerAssemblyMarkerType);

            services.AddScoped<IMessageBus, MessageBus>();
        }
    }
}
