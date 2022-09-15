using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskoMask.BuildingBlocks.Application.Behaviors;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Application.Notifications;

namespace TaskoMask.BuildingBlocks.Application.Services
{
    public static class ApplicationExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddBuildingBlocksApplicationServices(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddApplicationBehaviors();
            services.AddApplicationExceptionsHandler();
            services.AddDomainNotificationHandler();

            return services;
        }
    }
}
