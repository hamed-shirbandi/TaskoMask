using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Web.Services;

namespace TaskoMask.BuildingBlocks.Web;

/// <summary>
/// Shared Configuration for Web projects (Blazor, MVC and WebAPI)
/// </summary>
public static class Startup
{
    /// <summary>
    ///
    /// </summary>
    public static void AddHttpClientService(this IServiceCollection services)
    {
        services.AddScoped<IHttpClientService, HttpClientService>();
    }
}
