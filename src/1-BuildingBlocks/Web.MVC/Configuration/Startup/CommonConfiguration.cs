using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskoMask.BuildingBlocks.Web.MVC.Services.Cookie;
using TaskoMask.BuildingBlocks.Web.MVC.Services.AuthenticatedUser;
using TaskoMask.BuildingBlocks.Web.Configuration;

namespace TaskoMask.BuildingBlocks.Web.MVC.Configuration.Startup
{

    /// <summary>
    /// 
    /// </summary>
    public static class CommonConfiguration
    {


        /// <summary>
        /// 
        /// </summary>
        public static void AddCommonServices(this IServiceCollection services )
        {
            services.AddHttpContextAccessor();
            services.AddAuthenticatedUserService();
            services.AddCookieService();
            services.AddWebServerOptions();
        }



        /// <summary>
        /// 
        /// </summary>
        public static void UseCommonServices(this IApplicationBuilder app, IServiceProvider serviceProvider, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
        }





        /// <summary>
        /// 
        /// </summary>
        private static void AddWebServerOptions(this IServiceCollection services)
        {
            // If using Kestrel:
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

    }
}
