using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Team.Organizations.Services;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using TaskoMask.Web.Common.Controllers;
using TaskoMask.Domain.Core.Services;

namespace TaskoMask.Web.Admin.Areas.Administration.Controllers
{
    [Authorize]
    [Area("administration")]
    public class DashboardController : BaseMvcController
    {
        #region Fields

        private readonly IOrganizationService _organizationService;


        #endregion

        #region Ctors

        public DashboardController(IOrganizationService organizationService, IMapper mapper, IAuthenticatedUserService authenticatedUserService) : base(mapper, authenticatedUserService)
        {
            _organizationService = organizationService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<IActionResult> Index()
        {
            
            return View();
        }





        #endregion

    }
}
