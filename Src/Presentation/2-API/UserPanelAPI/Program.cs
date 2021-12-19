
using TaskoMask.Presentation.Framework.Web.Configuration.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.WebApiProjectConfigureServices(builder.Configuration);


var app = builder.Build();

app.WebApiProjectConfigure(app.Services, builder.Environment);


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
