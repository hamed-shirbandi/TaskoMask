using TaskoMask.Clients.Website.Configuration;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices().ConfigurePipeline(builder.Configuration);

app.Run();
