using TaskoMask.Application.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskoMask.Application.Core.Commands;
using AutoMapper;
using TaskoMask.Web.Common.Helpers;
using TaskoMask.Web.Common.Models;
using TaskoMask.Web.Common.Enums;
using System.Linq;

namespace TaskoMask.Web.Common.Controllers
{
    public class BaseApiController : Controller
    {
        #region Fields

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

        #endregion

        #region Protected Methods




        /// <summary>
        /// 
        /// </summary>
        protected string GetCurrentUserName()
        {
            if (this.User == null)
                return "";
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            if (!claimsIdentity.Claims.Any())
                return "";
            return claimsIdentity.Claims.FirstOrDefault(c => c.Type == "userName").Value;
        }



        /// <summary>
        /// 
        /// </summary>
        protected string GetCurrentUserId()
        {
            if (this.User == null)
                return "";

            ClaimsIdentity claimsIdentity = this.User.Identity as ClaimsIdentity;
            if (!claimsIdentity.Claims.Any())
                return "";
            return  claimsIdentity.Claims.FirstOrDefault(c => c.Type == "id").Value;
        }



    
        #endregion

        #region Private Methods


        #endregion

    }
}