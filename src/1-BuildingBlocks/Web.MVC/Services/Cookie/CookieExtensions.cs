using Microsoft.Extensions.DependencyInjection;

namespace TaskoMask.BuildingBlocks.Web.MVC.Services.Cookie
{
    public static class CookieExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddCookieService(this IServiceCollection services)
        {
            return services.AddScoped<ICookieService, CookieService>();
        }
    }
}
