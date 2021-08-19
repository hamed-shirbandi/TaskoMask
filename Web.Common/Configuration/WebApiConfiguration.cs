using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace TaskoMask.Web.Common.Configuration
{

    /// <summary>
    /// 
    /// </summary>
    public static class WebApiConfiguration
    {


        /// <summary>
        /// 
        /// </summary>
        public static IServiceProvider WebApiConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddControllers();
            return services.AddCommonConfigureServices(configuration);
        }



        /// <summary>
        /// 
        /// </summary>
        public static void WebApiConfigure(this IApplicationBuilder app, IServiceScopeFactory serviceScopeFactory, IWebHostEnvironment env)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCommonConfigure(serviceScopeFactory, env);

            app.UseRouting();
            app.UseAuthorization();
        }


    }
}
