using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace TaskoMask.BuildingBlocks.Infrastructure.Exceptions;

public static class ExceptionExtensions
{
    /// <summary>
    ///
    /// </summary>
    public static void AddApplicationExceptionHandlers(this IServiceCollection services)
    {
        services.AddManagedExceptionsHandler();
        services.AddUnmanagedExceptionsHandler();
    }

    /// <summary>
    ///
    /// </summary>
    private static void AddManagedExceptionsHandler(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRequestExceptionHandler<,,>), typeof(ManagedExceptionHandler<,,>));
    }

    /// <summary>
    ///
    /// </summary>
    private static void AddUnmanagedExceptionsHandler(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRequestExceptionHandler<,,>), typeof(UnmanagedExceptionHandler<,,>));
    }
}
