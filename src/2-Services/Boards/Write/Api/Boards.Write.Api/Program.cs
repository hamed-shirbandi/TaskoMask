
using TaskoMask.Services.Boards.Write.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices().ConfigurePipeline();

app.Run();