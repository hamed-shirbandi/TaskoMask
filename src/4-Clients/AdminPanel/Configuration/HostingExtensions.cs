using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Startup;
using TaskoMask.Services.Monolith.Infrastructure.CrossCutting.IoC;

namespace TaskoMask.Clients.AdminPanle.Configuration
{
    internal static class HostingExtensions
    {


        /// <summary>
        /// 
        /// </summary>
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {


            builder.AddCustomSerilog();

            builder.Services.AddProjectServices(builder.Configuration);

            builder.Services.AddMvcPreConfigured(builder.Configuration, builder.Environment);

            return builder.Build();
        }



        /// <summary>
        /// 
        /// </summary>
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {


            app.UseSerilogRequestLogging();

            app.UseMvcPreConfigured(app.Services, app.Environment);

            app.Services.InitialDatabasesAndSeedEssentialData();

            app.Services.GenerateAndSeedSampleData();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=login}/{id?}");

            });

            return app;
        }
    }
}