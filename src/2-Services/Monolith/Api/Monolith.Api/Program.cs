using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Startup;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.DataProviders;
using TaskoMask.Services.Monolith.Infrastructure.Data.Read.DataProviders;
using TaskoMask.Services.Monolith.Infrastructure.CrossCutting.IoC;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.AddCustomSerilog();

builder.Services.AddProjectConfigureServices();

builder.Services.AddWebApiConfigureServices(builder.Configuration);

var app = builder.Build();

app.UseSerilogRequestLogging();

app.UseWebApiProjectConfigure(app.Services, builder.Environment);

WriteDbInitialization.Initial(app.Services);
ReadDbInitialization.Initial(app.Services);
WriteDbSeedData.Seed(app.Services);


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();