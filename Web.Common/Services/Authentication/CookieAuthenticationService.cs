using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Users;

namespace TaskoMask.Web.Common.Services.Authentication
{
    /// <summary>
    /// Represents service using cookie for the authentication
    /// </summary>
    public class CookieAuthenticationService: ICookieAuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieAuthenticationService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 
        /// </summary>
        public virtual async Task<bool> SignIn(UserBasicInfoDto user, bool isPersistent)
        {
            //پسور رو هم بگیر چک کن پسوردش میخونه یا نه و یه مقدار ترو فالس هم برگردون
            //نحوه ذخیره بازیابی پسورد رو هم امن انجام بده
            //گرند نود اول پسورد طرف رو با LoginCustomer ولیدیت کرده
            //بعد اگر ولید بود فرستاده ساین این بشه

            if (user == null)
                return false;

            //create claims for user's username and email
            var claims = new List<Claim>();


            if (!string.IsNullOrEmpty(user.Email))
            {
                claims.Add(new Claim(ClaimTypes.Name, user.Email, ClaimValueTypes.String));
                claims.Add(new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id, ClaimValueTypes.String));
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                IsPersistent = isPersistent,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                IssuedUtc = DateTime.UtcNow,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);

            return true;
        }





        /// <summary>
        /// 
        /// </summary>
        public virtual async Task SignOut()
        {
            //and then sign out customer from the present scheme of authentication
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}