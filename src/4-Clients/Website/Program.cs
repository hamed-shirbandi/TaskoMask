using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Startup;

Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();
Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog(((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration)));
    builder.Services.AddMvcProjectConfigureServices(builder.Configuration, builder.Environment);
    var app = builder.Build();
    app.UseSerilogRequestLogging();
    app.UseMvcProjectConfigure(app.Services, builder.Environment);
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

    });
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}


