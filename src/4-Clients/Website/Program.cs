using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Startup;
using TaskoMask.Services.Monolith.Infrastructure.CrossCutting.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.AddCustomSerilog();

builder.Services.AddProjectServices();

builder.Services.AddMvcPreConfigured(builder.Configuration, builder.Environment);

var app = builder.Build();

app.UseSerilogRequestLogging();

app.UseMvcPreConfigured(app.Services, builder.Environment);

app.Services.InitialAdnSeedDatabases();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

});

app.Run();
