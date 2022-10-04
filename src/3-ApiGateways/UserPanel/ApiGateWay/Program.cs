using TaskoMask.ApiGateways.UserPanel.ApiGateway.Configuration;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices().ConfigurePipeline();

app.Run();