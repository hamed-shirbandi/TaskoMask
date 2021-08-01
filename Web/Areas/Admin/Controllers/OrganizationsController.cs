using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Organizations.Services;
using TaskoMask.Application.Core.Dtos.Organizations;
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
            return View(new OrganizationInputDto());
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(OrganizationInputDto input)
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
        public async Task<IActionResult> Update(OrganizationInputDto input)
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
