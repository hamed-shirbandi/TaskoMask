using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Metric;
using TaskoMask.BuildingBlocks.Web.MVC.Services.AuthenticatedUser;

namespace TaskoMask.BuildingBlocks.Web.MVC.Configuration
{

    /// <summary>
    /// 
    /// </summary>
    public static  class RazorPagesConfiguration
    {

        /// <summary>
        /// 
        /// </summary>
        public static void AddRazorPagesPreConfigured(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddRazorPages();

            services.AddAuthentication();

            services.AddHttpContextAccessor();

            services.AddAuthenticatedUserService();

            services.AddMetrics(configuration);
        }



        /// <summary>
        /// 
        /// </summary>
        public static void UseRazorPagesPreConfigured(this IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseMetrics(configuration);

            app.UseAuthorization();
        }


    }
}
