using TaskoMask.ApiGateways.UserPanel.Aggregator.Configuration;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var app = builder.ConfigureServices().ConfigurePipeline(builder.Configuration);

        app.Run();
    }
}