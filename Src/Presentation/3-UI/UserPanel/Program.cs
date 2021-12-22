using TaskoMask.Presentation.UI.UserPanel.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddProjectConfigureServices(builder.Configuration, builder.Environment);

var app = builder.Build();

app.UseProjectConfigure(builder.Environment);

app.Run();
