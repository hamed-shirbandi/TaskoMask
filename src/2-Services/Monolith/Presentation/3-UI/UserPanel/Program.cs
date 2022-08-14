using TaskoMask.Presentation.UI.UserPanel;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TaskoMask.Presentation.UI.UserPanel.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddProjectConfigureServices(builder.Configuration);

await builder.Build().RunAsync();
