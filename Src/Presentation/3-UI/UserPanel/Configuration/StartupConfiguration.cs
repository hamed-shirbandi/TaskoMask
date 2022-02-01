using Blazored.Modal;
using Blazored.Toast;
using TaskoMask.Presentation.Framework.Share.Configuration.Startup;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Presentation.Framework.Share.Services.Authentication.CookieAuthentication;
using TaskoMask.Presentation.UI.UserPanel.Services.Authentication;
using TaskoMask.Presentation.UI.UserPanel.Services.Data;
using TaskoMask.Presentation.UI.UserPanel.Services.Http;
using TaskoMask.Presentation.UI.UserPanel.Services.Message;

namespace TaskoMask.Presentation.UI.UserPanel.Configuration
{

    /// <summary>
    /// 
    /// </summary>
    public static class StartupConfiguration
    {

        /// <summary>
        /// 
        /// </summary>
        public static void AddProjectConfigureServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));


            services.AddRazorPages();
            services.AddServerSideBlazor();


            //add cookie authentication
            services.AddCookieAuthentication(env, options =>
             {
                 configuration.GetSection("Authentication").Bind(options);
             });

            //add HttpClient with an Interceptor to add jwt token to all requests automatically
            services.AddHttpClient(
                name: "ServerAPI",
                configureClient: client =>
                {
                    client.BaseAddress = new Uri(configuration.GetValue<string>("Url:UserPanelAPI"));
                    client.Timeout = TimeSpan.FromSeconds(50);
                }).AddHttpMessageHandler<HttpClientInterceptorService>();

            services.AddScoped<HttpClientInterceptorService>();
            services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ServerAPI"));


            services.AddClientServices();

            services.AddSharedConfigureServices();

            services.AddBlazoredToast();

            services.AddBlazoredModal();
        }



        /// <summary>
        /// 
        /// </summary>
        public static void UseProjectConfigure(this WebApplication app, IWebHostEnvironment env)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            // Configure the HTTP request pipeline.
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
        }



        /// <summary>
        /// 
        /// </summary>
        private static void AddClientServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAccountClientService, AccountClientService>();
            services.AddScoped<IOrganizationClientService, OrganizationClientService>();
            services.AddScoped<IProjectClientService, ProjectClientService>();
            services.AddScoped<IBoardClientService, BoardClientService>();
            services.AddScoped<ICardClientService, CardClientService>();
            services.AddScoped<ITaskClientService, TaskClientService>();
            services.AddScoped<IOwnerClientService, OwnerClientService>();
        }

    }
}
