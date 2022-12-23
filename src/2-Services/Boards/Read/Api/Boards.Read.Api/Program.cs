using Microsoft.AspNetCore.Builder;
using TaskoMask.Services.Boards.Read.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices().ConfigurePipeline();

app.Run();