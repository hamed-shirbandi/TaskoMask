using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace TaskoMask.BuildingBlocks.Application.Notifications
{
    public static class NotificationsExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddDomainNotificationHandler(this IServiceCollection services)
        {
            return services.AddScoped<INotificationHandler, NotificationHandler>();

        }
    }
}
