
using TaskoMask.Presentation.Framework.Web.Configuration.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.MvcConfigureServices(builder.Configuration, builder.Environment);


var app = builder.Build();

app.MvcConfigure(app.Services, builder.Environment);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

});

app.Run();
