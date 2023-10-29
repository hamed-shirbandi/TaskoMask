using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prometheus;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Metric;
using TaskoMask.BuildingBlocks.Web.MVC.Services.AuthenticatedUser;

namespace TaskoMask.BuildingBlocks.Web.MVC.Configuration
{
    /// <summary>
    ///
    /// </summary>
    public static class MvcConfiguration
    {
        /// <summary>
        ///
        /// </summary>
        public static void AddMvcPreConfigured(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddControllersWithViews();

            services.AddHttpContextAccessor();

            services.AddAuthenticatedUserService();

            services.AddWebServerOptions();

            services.AddMetrics(configuration);
        }

        /// <summary>
        ///
        /// </summary>
        public static void UseMvcPreConfigured(this IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error/Unknown");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseMetrics(configuration);

            app.UseAuthentication();

            app.UseAuthorization();
        }

        /// <summary>
        ///
        /// </summary>
        public static void AddWebServerOptions(this IServiceCollection services)
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
