using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;
using TaskoMask.Services.Identity.Api.Consumers;
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

            builder.Services.AddRazorPagesPreConfigured();

            builder.Services.AddModules(builder.Configuration, consumerAssemblyMarkerType:typeof(OwnerRegisteredConsumer));

            builder.Services.AddIdentityServer();

            return builder.Build();
        }



        /// <summary>
        /// 
        /// </summary>
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {

            app.UseSerilogRequestLogging();

            app.UseIdentityServer();

            app.UseRazorPagesPreConfigured(app.Environment);

            app.Services.InitialDatabasesAndSeedEssentialData();

            app.MapRazorPages().RequireAuthorization();

            return app;
        }
    }
}