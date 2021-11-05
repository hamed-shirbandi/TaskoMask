using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Team.Organizations.Services;
using TaskoMask.Application.Core.Dtos.Team.Organizations;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using TaskoMask.Web.Common.Controllers;
using TaskoMask.Domain.Core.Services;

namespace TaskoMask.Web.Area.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class OrganizationsController : BaseMvcController
    {
        #region Fields

        private readonly IOrganizationService _organizationService;

        #endregion

        #region Ctors

        public OrganizationsController(IOrganizationService organizationService, IMapper mapper, IAuthenticatedUserService authenticatedUserService) : base(mapper, authenticatedUserService)
        {
            _organizationService = organizationService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var organizationDetailQueryResult = await _organizationService.GetDetailsAsync(id);
            return View(organizationDetailQueryResult);

        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(OrganizationUpsertDto input)
        {
            input.OwnerMemberId = GetCurrentUserId();
            var cmdResult = await _organizationService.CreateAsync(input);
            if (!cmdResult.IsSuccess)
                return View(cmdResult, input);

            return RedirectToAction(actionName:"index",controllerName:"dashboard");
        }




        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var organizationQueryResult = await _organizationService.GetByIdAsync(id);
            return View<OrganizationBasicInfoDto, OrganizationUpsertDto>(organizationQueryResult);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Update(OrganizationUpsertDto input)
        {
            var cmdResult = await _organizationService.UpdateAsync(input);
            return View(cmdResult, input);
        }



        #endregion

    }
}
