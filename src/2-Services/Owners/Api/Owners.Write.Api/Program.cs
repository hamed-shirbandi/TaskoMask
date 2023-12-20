using Microsoft.AspNetCore.Builder;
using TaskoMask.Services.Owners.Write.Api.Configuration;

namespace TaskoMask.Services.Owners.Write.Api;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var app = builder.ConfigureServices().ConfigurePipeline(builder.Configuration);

        app.Run();
    }
}