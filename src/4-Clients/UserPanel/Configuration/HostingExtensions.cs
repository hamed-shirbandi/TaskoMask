using Blazored.Modal;
using Blazored.Toast;
using TaskoMask.Clients.UserPanel.Services.DragDrop;
using TaskoMask.Clients.UserPanel.Services.ComponentMessage;
using TaskoMask.BuildingBlocks.Web.Configuration;
using TaskoMask.Clients.UserPanel.Services.API;
using TaskoMask.Clients.UserPanel.Helpers;

namespace TaskoMask.Clients.UserPanel.Configuration
{

    /// <summary>
    /// 
    /// </summary>
    public static class HostingExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

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
            services.AddHttpClient(name: MagicKey.Protected_ApiGateway_Client, configureClient: client =>
            {
                client.BaseAddress = new Uri(configuration.GetValue<string>("Url:ApiGateway"));
                client.Timeout = TimeSpan.FromSeconds(50);
            }).AddHttpMessageHandler<IdentityServerAuthorizationHandler>();

            //For Anonymous APIs
            services.AddHttpClient(name: MagicKey.Public_ApiGateway_Client, configureClient: client =>
            {
                client.BaseAddress = new Uri(configuration.GetValue<string>("Url:ApiGateway"));
                client.Timeout = TimeSpan.FromSeconds(50);
            });

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
}
