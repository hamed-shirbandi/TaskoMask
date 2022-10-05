using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Web.Services.Http;

namespace TaskoMask.BuildingBlocks.Web.Configuration
{
    /// <summary>
    /// Shared Configuration for Web projects (Blazor, MVC and WebAPI)
    /// </summary>
    public static class SharedConfiguration
    {



        /// <summary>
        /// 
        /// </summary>
        public static void AddHttpClientService(this IServiceCollection services)
        {
            services.AddScoped<IHttpClientService, HttpClientService>();
        }

    }
}
