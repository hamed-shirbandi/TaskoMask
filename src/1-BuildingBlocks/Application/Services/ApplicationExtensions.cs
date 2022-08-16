using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddApplicationBehaviors();
            services.AddApplicationExceptionsHandler();
            services.AddDomainNotificationHandler();

            return services;
        }
    }
}
