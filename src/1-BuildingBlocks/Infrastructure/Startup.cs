using System;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Infrastructure.Behaviors;
using TaskoMask.BuildingBlocks.Infrastructure.Exceptions;
using TaskoMask.BuildingBlocks.Infrastructure.MassTransit;
using TaskoMask.BuildingBlocks.Infrastructure.Services;
using TaskoMask.BuildingBlocks.Infrastructure.Services.EventStoring;

namespace TaskoMask.BuildingBlocks.Infrastructure;

public static class Startup
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
        services.AddNotificationService();
        services.AddMessageBus(configuration, consumerAssemblyMarkerType);
        services.AddRedisEventStoreService();
    }

    private static void AddNotificationService(this IServiceCollection services)
    {
        services.AddScoped<INotificationService, NotificationService>();
    }

    private static void AddInMemoryBus(this IServiceCollection services, Type handlerAssemblyMarkerType)
    {
        //Load all handlers from given assemblies
        services.AddMediatR(handlerAssemblyMarkerType);

        services.AddScoped<IRequestDispatcher, MediatRDispatcher>();
    }

    private static void AddMessageBus(this IServiceCollection services, IConfiguration configuration, Type consumerAssemblyMarkerType)
    {
        services.AddMassTransitWithRabbitMqTransport(configuration, consumerAssemblyMarkerType);

        services.AddScoped<IEventPublisher, MassTransitEventPublisher>();
    }

    private static void AddApplicationBehaviors(this IServiceCollection services, Type validatorAssemblyMarkerType)
    {
        services.AddValidationBehaviour(validatorAssemblyMarkerType);
        services.AddCachingBehavior();
        services.AddEventStoringBehavior();
    }

    private static void AddValidationBehaviour(this IServiceCollection services, Type validatorAssemblyMarkerType)
    {
        //Load all fluent validation classes to be used in ValidationBehaviour
        services.AddValidatorsFromAssembly(validatorAssemblyMarkerType.Assembly);

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
    }

    private static void AddEventStoringBehavior(this IServiceCollection services)
    {
        services.AddScoped<INotificationHandler<DomainEvent>, EventStoringBehavior>();
    }

    private static void AddCachingBehavior(this IServiceCollection services)
    {
        services.AddEasyCaching(option => option.UseInMemory());
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
    }

    private static IServiceCollection AddRedisEventStoreService(this IServiceCollection services)
    {
        return services.AddScoped<IEventStoreService, RedisEventStoreService>();
    }

    private static void AddApplicationExceptionHandlers(this IServiceCollection services)
    {
        services.AddManagedExceptionsHandler();
        services.AddUnmanagedExceptionsHandler();
    }

    private static void AddManagedExceptionsHandler(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRequestExceptionHandler<,,>), typeof(ManagedExceptionHandler<,,>));
    }

    private static void AddUnmanagedExceptionsHandler(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRequestExceptionHandler<,,>), typeof(UnmanagedExceptionHandler<,,>));
    }
}
