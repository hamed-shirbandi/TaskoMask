using MMLib.SwaggerForOcelot.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddOcelotWithSwaggerSupport((o) =>
{
    o.Folder = "Configuration";
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOcelot();

builder.Services.AddSwaggerForOcelot(builder.Configuration);

var app = builder.Build();

app.UseStaticFiles();

app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";
});

app.UseOcelot().Wait();

app.Run();