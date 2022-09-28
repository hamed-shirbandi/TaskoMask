using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Contracts.Services;

namespace TaskoMask.BuildingBlocks.Web.MVC.Controllers
{
    [Authorize("ApiScope")]
    public class BaseApiController : Controller
    {
        #region Fields

        private readonly IAuthenticatedUserService _authenticatedUserService;

        #endregion

        #region Ctors


        public BaseApiController( )
        {
        }


        public BaseApiController(IAuthenticatedUserService authenticatedUserService)
        {
            _authenticatedUserService = authenticatedUserService;
        }



        #endregion

        #region Protected Methods



        /// <summary>
        /// 
        /// </summary>
        protected string GetCurrentUserName()
        {
            return _authenticatedUserService.GetUserName();
        }



        /// <summary>
        /// 
        /// </summary>
        protected string GetCurrentUserId()
        {
            return _authenticatedUserService.GetUserId();
        }



        #endregion

        #region Private Methods


        #endregion

    }
}