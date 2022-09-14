using TaskoMask.ApiGateways.UserPanel.Aggregator.Configuration;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices().ConfigurePipeline();

app.Run();