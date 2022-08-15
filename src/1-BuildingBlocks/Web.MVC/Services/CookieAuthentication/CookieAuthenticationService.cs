using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using TaskoMask.BuildingBlocks.Contracts.Models;
using TaskoMask.BuildingBlocks.Web.Extensions;

namespace TaskoMask.BuildingBlocks.Web.MVC.Services.Authentication.CookieAuthentication
{
    /// <summary>
    /// Represents service using cookie for the authentication
    /// </summary>
    public class CookieAuthenticationService : ICookieAuthenticationService
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly MVC.Models.CookieAuthenticationOptions _options;


        #endregion

        #region Ctors

        public CookieAuthenticationService(IHttpContextAccessor httpContextAccessor, IOptions<MVC.Models.CookieAuthenticationOptions> options) 
        {
            _options = options != null ? options.Value : throw new ArgumentNullException(nameof(options));
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task SignInAsync(AuthenticatedUserModel user, bool isPersistent)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            //create claims for user
            var claims = new List<Claim>();
            claims.AddList(user);


            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = _options.AllowRefresh,
                IsPersistent = isPersistent,
                IssuedUtc = DateTime.UtcNow,
            };

            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        }





        /// <summary>
        /// 
        /// </summary>
        public async Task SignOutAsync()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }




        #endregion

        #region Private Methods



        #endregion

    }
}