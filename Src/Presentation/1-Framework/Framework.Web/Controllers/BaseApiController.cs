using TaskoMask.Application.Share.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskoMask.Application.Core.Commands;
using AutoMapper;
using TaskoMask.Presentation.Framework.Web.Helpers;
using TaskoMask.Presentation.Framework.Web.Models;
using TaskoMask.Presentation.Framework.Web.Enums;
using System.Linq;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.Share.Services;

namespace TaskoMask.Presentation.Framework.Web.Controllers
{
    public class BaseApiController : Controller
    {
        #region Fields

        private readonly IAuthenticatedUserService _authenticatedUserService;
        protected readonly IMapper _mapper;

        #endregion

        #region Ctors

        public BaseApiController()
        {

        }


        public BaseApiController(IMapper mapper)
        {
            _mapper = mapper;
        }



        public BaseApiController(IMapper mapper, IAuthenticatedUserService authenticatedUserService)
        {
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
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