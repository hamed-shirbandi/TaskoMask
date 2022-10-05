using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;
using TaskoMask.Services.Identity.Infrastructure.CrossCutting.DI;

namespace TaskoMask.Services.Identity.Api.Configuration
{
    internal static class HostingExtensions
    {


        /// <summary>
        /// 
        /// </summary>
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.AddCustomSerilog();

            builder.Services.AddRazorPages();

            builder.Services.AddModules(builder.Configuration);

            builder.Services.AddIdentityServer();

            builder.Services.AddAuthentication();

            return builder.Build();
        }



        /// <summary>
        /// 
        /// </summary>
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.MapRazorPages().RequireAuthorization();

            InfrastructureModule.InitialDatabasesAndSeedEssentialData(app.Services);

            return app;
        }
    }
}