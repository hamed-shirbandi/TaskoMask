using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TaskoMask.BuildingBlocks.Infrastructure.MassTransit
{
    public static class MassTransitExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static void AddMassTransitWithRabbitMqTransport(this IServiceCollection services, IConfiguration configuration, Type consumerAssemblyMarkerType)
        {
            var rabbitMqOptions = configuration.GetSection("RabbitMQ").Get<RabbitMqOptions>();

            services.AddMassTransit(x =>
            {
                x.AddConsumers(consumerAssemblyMarkerType.Assembly);

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(rabbitMqOptions.Host, h =>
                    {
                        h.Username(rabbitMqOptions.UserName);
                        h.Password(rabbitMqOptions.Password);
                    });

                    cfg.ReceiveEndpoint(rabbitMqOptions.ExchangeName, e =>
                    {
                        e.ConfigureConsumers(context);
                    });
                });

            });
        }
    }
}
