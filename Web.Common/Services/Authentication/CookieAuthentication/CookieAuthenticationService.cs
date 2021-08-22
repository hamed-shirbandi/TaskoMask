using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Web.Common.Services.Authentication.Models;

namespace TaskoMask.Web.Common.Services.Authentication.CookieAuthentication
{
    /// <summary>
    /// Represents service using cookie for the authentication
    /// </summary>
    public class CookieAuthenticationService : ICookieAuthenticationService
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Models.CookieAuthenticationOptions _options;


        #endregion

        #region Ctors

        public CookieAuthenticationService(IHttpContextAccessor httpContextAccessor, IOptions<Models.CookieAuthenticationOptions> options)
        {
            _options = options != null ? options.Value : throw new ArgumentNullException(nameof(options));
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task SignInAsync(UserBasicInfoDto user, bool isPersistent)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            //create claims for user's username and email
            var claims = new List<Claim>();

            if (!string.IsNullOrEmpty(user.Email))
            {
                claims.Add(new Claim(ClaimTypes.Name, user.Email, ClaimValueTypes.String));
                claims.Add(new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id, ClaimValueTypes.String));
                claims.Add(new Claim(nameof(AuthenticatedUserModel.DisplayName), user.DisplayName, ClaimValueTypes.String));
            }

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



        /// <summary>
        /// 
        /// </summary>
        public AuthenticatedUserModel GetAuthenticatedUser()
        {
            var user = _httpContextAccessor.HttpContext.User;
            if (user == null)
                return null;

            return new AuthenticatedUserModel
            {
                Id = user.FindFirstValue(ClaimTypes.NameIdentifier) ?? "",
                Email = user.FindFirstValue(ClaimTypes.Email) ?? "",
                UserName = user.FindFirstValue(ClaimTypes.Name) ?? "",
                DisplayName = user.FindFirstValue(nameof(AuthenticatedUserModel.DisplayName)) ?? "",
            };

        }




        /// <summary>
        /// 
        /// </summary>
        public bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }

        #endregion

        #region Private Methods



        #endregion

    }
}