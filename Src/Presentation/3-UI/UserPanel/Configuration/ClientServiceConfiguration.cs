using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Presentation.UI.UserPanel.Services.Authentication;
using TaskoMask.Presentation.UI.UserPanel.Services.Data;

namespace TaskoMask.Presentation.UI.UserPanel.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public static class ClientServiceConfiguration
    {


        /// <summary>
        /// 
        /// </summary>
        public static void AddClientServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAccountClientService, AccountClientService>();
            services.AddScoped<IOrganizationClientService, OrganizationClientService>();
        }

    }
}
