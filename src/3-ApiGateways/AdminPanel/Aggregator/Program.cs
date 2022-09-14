
using TaskoMask.ApiGateways.AdminPanel.Aggregator.Configuration;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices().ConfigurePipeline();

app.Run();