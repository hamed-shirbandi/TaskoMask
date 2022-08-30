using MMLib.SwaggerForOcelot.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.AddCustomSerilog();

builder.Configuration.AddOcelotWithSwaggerSupport((o) =>
{
    o.Folder = "Configuration";
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOcelot();

builder.Services.AddSwaggerForOcelot(builder.Configuration);

var app = builder.Build();

app.UseSerilogRequestLogging();

app.UseStaticFiles();

app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";
});

app.UseOcelot().Wait();

app.Run();