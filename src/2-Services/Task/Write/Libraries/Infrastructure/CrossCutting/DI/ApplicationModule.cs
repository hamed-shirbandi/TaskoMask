using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Application.Behaviors;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Application.Notifications;

namespace TaskoMask.Services.Task.Infrastructure.CrossCutting.DI
{

    /// <summary>
    /// 
    /// </summary>
    internal static class ApplicationModule
    {

  
        /// <summary>
        /// 
        /// </summary>
        public static void AddApplicationModule(this IServiceCollection services)
        {
            services.AddValidationBehaviour();
            services.AddApplicationExceptionsHandler();
            services.AddDomainNotificationHandler();
            services.AddEventStoringBehavior();
        }


    }
}
