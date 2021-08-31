using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Services;

namespace TaskoMask.Infrastructure.CrossCutting.Services.Security
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;


        #endregion

        #region Ctors

        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public AuthenticatedUser GetAuthenticatedUser()
        {
            var user = _httpContextAccessor.HttpContext.User;
            if (user == null)
                return null;

            return new AuthenticatedUser
            {
                Id = user.FindFirstValue(ClaimTypes.NameIdentifier) ?? "",
                Email = user.FindFirstValue(ClaimTypes.Email) ?? "",
                UserName = user.FindFirstValue(ClaimTypes.Name) ?? "",
                DisplayName = user.FindFirstValue(nameof(AuthenticatedUser.DisplayName)) ?? "",
            };

        }



        /// <summary>
        /// 
        /// </summary>
        public string GetUserId()
        {
            var user = _httpContextAccessor.HttpContext.User;
            if (user == null)
                return "";
            return user.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
        }




        /// <summary>
        /// 
        /// </summary>
        public string GetUserName()
        {
            var user = _httpContextAccessor.HttpContext.User;
            if (user == null)
                return "";
            return user.FindFirstValue(ClaimTypes.Name) ?? "";
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
