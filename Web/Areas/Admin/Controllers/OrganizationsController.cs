using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Organizations.Services;
using TaskoMask.Application.Core.Dtos.Organizations;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using TaskoMask.Web.Common.Controllers;

namespace TaskoMask.Web.Area.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class OrganizationsController : BaseController
    {
        #region Fields

        private readonly IOrganizationService _organizationService;

        #endregion

        #region Ctors

        public OrganizationsController(IOrganizationService organizationService, IMapper mapper) : base(mapper)
        {
            _organizationService = organizationService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            var organizationDetailQueryResult = await _organizationService.GetDetailAsync(id);
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
        public async Task<IActionResult> Create(OrganizationInputDto input)
        {
            if (!ModelState.IsValid)
                return View(input);

            var cmdResult = await _organizationService.CreateAsync(input);
            return View(cmdResult, input);
        }




        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var organizationQueryResult = await _organizationService.GetByIdAsync(id);
            return View<OrganizationBasicInfoDto, OrganizationInputDto>(organizationQueryResult);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Update(OrganizationInputDto input)
        {
            if (!ModelState.IsValid)
                return View(input);

            var cmdResult = await _organizationService.UpdateAsync(input);
            return View(cmdResult, input);
        }



        #endregion

    }
}
