using Serilog;
using TaskoMask.Services.Monolith.Infrastructure.Data.Generator;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Startup;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;
using TaskoMask.Services.Monolith.Infrastructure.CrossCutting.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.AddCustomSerilog();

builder.Services.AddProjectConfigureServices();

builder.Services.AddMvcPreConfigured(builder.Configuration, builder.Environment);

var app = builder.Build();

SampleDataGenerator.GenerateAndSeedSampleData(app.Services);

app.UseSerilogRequestLogging();

app.UseMvcPreConfigured(app.Services, builder.Environment);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Account}/{action=login}/{id?}");

});

app.Run();
