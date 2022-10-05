using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.BuildingBlocks.Web.MVC.Services.AuthenticatedUser
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
        public AuthenticatedUserModel GetAuthenticatedUser()
        {
            var user = _httpContextAccessor.HttpContext.User;
            if (user == null)
                return new AuthenticatedUserModel();

            return new AuthenticatedUserModel
            {
                Id = user.FindFirstValue(ClaimTypes.NameIdentifier) ?? "",
                Email = user.FindFirstValue(ClaimTypes.Email) ?? "",
                UserName = user.FindFirstValue(ClaimTypes.Name) ?? "",
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
