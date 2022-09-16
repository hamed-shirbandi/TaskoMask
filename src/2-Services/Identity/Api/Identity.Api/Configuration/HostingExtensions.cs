using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;
using TaskoMask.Services.Identity.Infrastructure.CrossCutting.DI;
using TaskoMask.Services.Identity.Infrastructure.Data.DataProviders;

namespace TaskoMask.Services.Identity.Api.Configuration
{
    internal static class HostingExtensions
    {


        /// <summary>
        /// 
        /// </summary>
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {

            builder.Services.AddModules(builder.Configuration);

            builder.AddCustomSerilog();

            builder.Services.AddRazorPages();

            builder.Services.AddIdentityServer();

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

            DbSeedData.SeedEssentialData(app.Services);

            return app;
        }
    }
}