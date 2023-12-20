using Microsoft.AspNetCore.Builder;
using TaskoMask.Services.Tasks.Read.Api.Configuration;

namespace TaskoMask.Services.Tasks.Read.Api;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var app = builder.ConfigureServices().ConfigurePipeline(builder.Configuration);

        app.Run();
    }
}