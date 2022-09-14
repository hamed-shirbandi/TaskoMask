using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Startup;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;
using TaskoMask.Services.Identity.Infrastructure.CrossCutting.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.AddCustomSerilog();

builder.Services.AddProjectServices(builder.Configuration);

builder.Services.AddWebApiPreConfigured(builder.Configuration);

var app = builder.Build();

app.UseSerilogRequestLogging();

app.UseWebApiPreConfigured(app.Services, builder.Environment);

//app.Services.InitialDatabasAndSeedEssentialData();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();