using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Startup;

Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();
Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog(((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration)));
    builder.Services.AddWebApiProjectConfigureServices(builder.Configuration);
    var app = builder.Build();
    app.UseSerilogRequestLogging();
    app.UseWebApiProjectConfigure(app.Services, builder.Environment);
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
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

