using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TaskoMask.Services.Identity.Api.Infrastructure.CrossCutting.DI;

/// <summary>
///
/// </summary>
public static class ModuleExtensions
{
    /// <summary>
    ///
    /// </summary>
    public static void AddModules(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructureModule(configuration);
    }
}
