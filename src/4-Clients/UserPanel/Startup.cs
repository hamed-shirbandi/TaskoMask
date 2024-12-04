using Blazored.Modal;
using Blazored.Toast;
using TaskoMask.BuildingBlocks.Web;
using TaskoMask.Clients.UserPanel.Configuration;
using TaskoMask.Clients.UserPanel.Helpers;
using TaskoMask.Clients.UserPanel.Services.API;
using TaskoMask.Clients.UserPanel.Services.ComponentMessage;
using TaskoMask.Clients.UserPanel.Services.DragDrop;

namespace TaskoMask.Clients.UserPanel;

/// <summary>
///
/// </summary>
public static class Startup
{
    /// <summary>
    ///
    /// </summary>
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddHttpServices(configuration);
        services.AddApiServices();
        services.AddComponentMessageServices();
        services.AddDragDropServices();
        services.AddBlazoredToast();
        services.AddBlazoredModal();
        services.AddOidcAuthentication(options =>
        {
            configuration.Bind("oidc", options.ProviderOptions);
        });
    }

    /// <summary>
    ///
    /// </summary>
    private static void AddHttpServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IdentityServerAuthorizationHandler>();

        //For Authorized APIs
        services
            .AddHttpClient(
                name: MagicKey.PROTECTED_APIGATEWAY_CLIENT,
                configureClient: client =>
                {
                    client.BaseAddress = new Uri(configuration.GetValue<string>("Url:ApiGateway"));
                    client.Timeout = TimeSpan.FromSeconds(50);
                }
            )
            .AddHttpMessageHandler<IdentityServerAuthorizationHandler>();

        //For Anonymous APIs
        services.AddHttpClient(
            name: MagicKey.PUBLIC_APIGATEWAY_CLIENT,
            configureClient: client =>
            {
                client.BaseAddress = new Uri(configuration.GetValue<string>("Url:ApiGateway"));
                client.Timeout = TimeSpan.FromSeconds(50);
            }
        );

        services.AddHttpClientService();
    }

    /// <summary>
    ///
    /// </summary>
    private static void AddComponentMessageServices(this IServiceCollection services)
    {
        services.AddScoped<IComponentMessageService, ComponentMessageService>();
    }

    /// <summary>
    ///
    /// </summary>
    private static void AddDragDropServices(this IServiceCollection services)
    {
        services.AddScoped<IDragDropService, DragDropService>();
    }

    /// <summary>
    ///
    /// </summary>
    private static void AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<OwnerApiService>();
        services.AddScoped<OrganizationApiService>();
        services.AddScoped<ProjectApiService>();
        services.AddScoped<BoardApiService>();
        services.AddScoped<CardApiService>();
        services.AddScoped<TaskApiService>();
        services.AddScoped<CommentApiService>();
    }
}
