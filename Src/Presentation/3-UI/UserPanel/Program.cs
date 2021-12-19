
using TaskoMask.Presentation.Framework.Share.Configuration.Startup;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Presentation.UI.UserPanel.Services.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSharedConfigureServices(builder.Configuration.GetValue<string>("Url:UserPanelAPI"));

builder.Services.AddScoped<IAccountClientService, AccountClientService>();
builder.Services.AddScoped<IOrganizationClientService, OrganizationClientService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
