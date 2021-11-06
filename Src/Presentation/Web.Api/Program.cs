using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using StructureMap.AspNetCore;

namespace TaskoMask.Web.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
            .UseStructureMap()
               .UseStartup<Startup>()
               .Build();
    }
}
