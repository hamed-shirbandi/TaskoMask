
using TaskoMask.Infrastructure.Data.DataProviders;
using TaskoMask.Web.Common.Configuration.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.WebApiConfigureServices(builder.Configuration);


var app = builder.Build();

app.WebApiConfigure(app.Services, builder.Environment);


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
