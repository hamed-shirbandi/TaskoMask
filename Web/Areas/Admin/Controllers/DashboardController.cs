using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Team.Organizations.Services;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.Web.Area.Admin.Models;
using AutoMapper;
using TaskoMask.Web.Common.Controllers;
using TaskoMask.Domain.Core.Services;

namespace TaskoMask.Web.Area.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
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
            var organizationsDetailQueryResult = await _organizationService.GetUserOrganizationsDetailAsync(GetCurrentUserId());
            if (!organizationsDetailQueryResult.IsSuccess)
                return RedirectToErrorPage(organizationsDetailQueryResult);

            var model = new DashboardIndexViewModel
            {
                OrganizationsDetailsList = organizationsDetailQueryResult.Value,
            };
            return View(model);
        }





        #endregion

    }
}
