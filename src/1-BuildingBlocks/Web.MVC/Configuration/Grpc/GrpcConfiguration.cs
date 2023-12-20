using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Web.MVC.Exceptions;

namespace TaskoMask.BuildingBlocks.Web.MVC.Configuration.Grpc;

/// <summary>
///
/// </summary>
public static class GrpcConfiguration
{
    /// <summary>
    ///
    /// </summary>
    public static void AddGrpcPreConfigured(this IServiceCollection services)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        services.AddGrpc(options =>
        {
            options.Interceptors.Add<GrpcGlobalExceptionHandler>();
        });
    }
}
