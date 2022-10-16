using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Jwt;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Swagger;
using TaskoMask.BuildingBlocks.Web.MVC.Services.AuthenticatedUser;
using TaskoMask.BuildingBlocks.Web.MVC.Services.Cookie;

namespace TaskoMask.BuildingBlocks.Web.MVC.Configuration
{

    /// <summary>
    /// 
    /// </summary>
    public static class WebApiConfiguration
    {


        /// <summary>
        /// 
        /// </summary>
        public static void AddWebApiPreConfigured(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddControllers().WithPreventAutoValidation();

            services.AddSwaggerPreConfigured(options =>
            {
                configuration.GetSection("Swagger").Bind(options);
            });

            services.AddHttpContextAccessor();

            services.AddAuthenticatedUserService();

            services.AddCookieService();

            services.AddWebServerOptions();

            services.AddJwtAuthentication(configuration);

            services.AddCors();
        }



        /// <summary>
        /// 
        /// </summary>
        public static void UseWebApiPreConfigured(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwaggerPreConfigured();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();
        }



        /// <summary>
        /// Prevent auto validate on model binding
        /// </summary>
        private static IMvcBuilder WithPreventAutoValidation(this IMvcBuilder builder)
        {
            return builder.ConfigureApiBehaviorOptions(options =>
                  {
                      options.SuppressModelStateInvalidFilter = true;
                  });
        }
    }
}
