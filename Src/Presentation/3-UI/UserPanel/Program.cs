using TaskoMask.Presentation.Framework.Share.Configuration.Startup;
using TaskoMask.Presentation.UI.UserPanel.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.BlazorProjectConfigureServices(builder.Configuration, builder.Environment);
builder.Services.AddClientDataServices();

var app = builder.Build();

app.BlazorProjectConfigure(builder.Environment);
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
