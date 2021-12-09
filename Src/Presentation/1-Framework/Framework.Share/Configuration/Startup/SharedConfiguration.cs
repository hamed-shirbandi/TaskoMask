using Microsoft.Extensions.DependencyInjection;
using TaskoMask.Presentation.Framework.Share.Services.Http;

namespace TaskoMask.Presentation.Framework.Share.Configuration.Startup
{
    /// <summary>
    /// Shared Configuration for Blazor and MVC and WebAPI projects
    /// </summary>
    public static class SharedConfiguration
    {


        /// <summary>
        /// 
        /// </summary>
        public static void AddSharedConfigureServices(this IServiceCollection services,string httpClientBaseAddress)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(httpClientBaseAddress)
            });

            services.AddScoped<IHttpClientServices, HttpClientServices>();
        }

    }
}
