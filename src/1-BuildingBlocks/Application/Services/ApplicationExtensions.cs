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
        public static void AddBuildingBlocksApplication(this IServiceCollection services, Type validatorAssemblyMarkerType)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddApplicationExceptionsHandler();
            services.AddApplicationBehaviors(validatorAssemblyMarkerType);
            services.AddDomainNotificationHandler();
        }
    }
}
