using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Infrastructure.Behaviors;
using TaskoMask.BuildingBlocks.Infrastructure.Bus;
using TaskoMask.BuildingBlocks.Infrastructure.EventSourcing;
using TaskoMask.BuildingBlocks.Infrastructure.Exceptions;
using TaskoMask.BuildingBlocks.Infrastructure.Notifications;

namespace TaskoMask.BuildingBlocks.Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    /// <summary>
    ///
    /// </summary>
    public static void AddBuildingBlocksInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,
        Type consumerAssemblyMarkerType,
        Type handlerAssemblyMarkerType,
        Type validatorAssemblyMarkerType
    )
    {
        services.AddInMemoryBus(handlerAssemblyMarkerType);
        services.AddApplicationExceptionHandlers();
        services.AddApplicationBehaviors(validatorAssemblyMarkerType);
        services.AddDomainNotificationHandler();
        services.AddMessageBus(configuration, consumerAssemblyMarkerType);
        services.AddRedisEventStoreService();
    }
}
