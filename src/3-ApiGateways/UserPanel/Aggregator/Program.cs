using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Startup;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.AddCustomSerilog();

builder.Services.AddWebApiPreConfigured(builder.Configuration);

var app = builder.Build();

app.UseSerilogRequestLogging();

app.UseWebApiPreConfigured(app.Services, builder.Environment);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();