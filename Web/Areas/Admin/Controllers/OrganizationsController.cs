using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Services.Organizations;
using TaskoMask.Application.Services.Organizations.Dto;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Models;
using TaskoMask.Domain.Core.Events;
using TaskoMask.web.Models;
using Microsoft.AspNetCore.Authorization;

namespace TaskoMask.web.Area.Admin.Controllers
{
    [Authorize]
     [Area("admin")]
    public class OrganizationsController : BaseController
    {
        #region Fields

        private readonly IOrganizationService _organizationService;

        #endregion

        #region Ctor

        public OrganizationsController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = GetCurrentUserId();
            var organizations = await _organizationService.GetListByUserIdAsync(userId);
            return View(organizations);
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
        public async Task<IActionResult> Create(OrganizationInput input)
        {
            if (!ModelState.IsValid)
                return View(input);

            input.UserId = GetCurrentUserId();

            var result = await _organizationService.CreateAsync(input);
            ValidateResult(result);

            return View(input);
        }




        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var organization = await _organizationService.GetByIdToUpdateAsync(id);
            return View(organization);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Update(OrganizationInput input)
        {
            if (!ModelState.IsValid)
                return View(input);

            var result = await _organizationService.UpdateAsync(input);

            ValidateResult(result);

            return View(input);
        }



        #endregion

    }
}
