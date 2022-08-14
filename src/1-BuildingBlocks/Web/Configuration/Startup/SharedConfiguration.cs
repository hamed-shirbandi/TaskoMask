using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Web.Services.Http;

namespace TaskoMask.BuildingBlocks.Web.Configuration.Startup
{
    /// <summary>
    /// Shared Configuration for Blazor and MVC and WebAPI projects
    /// </summary>
    public static class SharedConfiguration
    {


        /// <summary>
        /// 
        /// </summary>
        public static void HttpClientService(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<IHttpClientService, HttpClientService>();
        }

    }
}
