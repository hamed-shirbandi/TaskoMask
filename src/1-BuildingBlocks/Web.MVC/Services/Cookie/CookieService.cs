
using Microsoft.AspNetCore.Http;

namespace TaskoMask.Services.Monolith.Presentation.Framework.Web.Services.Cookie
{
    public class CookieService : ICookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;



        /// <summary>
        /// 
        /// </summary>
        public CookieService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }



        /// <summary>
        /// 
        /// </summary>
        public string Get(string key)
        {
            return _httpContextAccessor.HttpContext.Request.Cookies[key];
        }



        /// <summary>
        /// 
        /// </summary>
        public void Set(string key, string value)
        {
            CookieOptions option = new CookieOptions
            {
                HttpOnly=true,
            };

            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, option);

        }



        /// <summary>
        /// 
        /// </summary>
        public void Remove(string key)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
        }
    }
}
