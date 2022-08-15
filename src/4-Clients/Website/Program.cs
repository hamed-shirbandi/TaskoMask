using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Startup;
using TaskoMask.Services.Monolith.Infrastructure.CrossCutting.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.AddCustomSerilog();

builder.Services.AddProjectConfigureServices();

builder.Services.AddMvcConfigureServices(builder.Configuration, builder.Environment);

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
