
using TaskoMask.Presentation.Framework.Web.Configuration.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.WebApiConfigureServices(builder.Configuration);


var app = builder.Build();

app.WebApiConfigure(app.Services, builder.Environment);


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
