using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Application.Notifications;

namespace TaskoMask.BuildingBlocks.Infrastructure.Notifications;

public static class NotificationsExtensions
{
    /// <summary>
    ///
    /// </summary>
    public static void AddDomainNotificationHandler(this IServiceCollection services)
    {
        services.AddScoped<INotificationHandler, NotificationHandler>();
    }
}
