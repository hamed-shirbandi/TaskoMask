using Microsoft.AspNetCore.Builder;

namespace TaskoMask.Services.Boards.Write.Api;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var app = builder.ConfigureServices().ConfigurePipeline();

        app.Run();
    }
}
