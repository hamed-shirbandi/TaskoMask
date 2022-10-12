
using TaskoMask.Services.Owners.Write.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices().ConfigurePipeline();

app.Run();