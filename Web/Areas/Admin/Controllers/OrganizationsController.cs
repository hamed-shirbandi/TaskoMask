using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Organizations.Services;
using TaskoMask.Application.Core.Dtos.Organizations;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.Organizations.Queries.Models;
using TaskoMask.Application.Organizations.Commands.Models;
using AutoMapper;

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

        public OrganizationsController(IOrganizationService organizationService, IBaseApplicationService baseApplicationService, IMapper mapper) : base(baseApplicationService, mapper)
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
            return ReturnDataToViewAsync(organizationDetailQueryResult);
      
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

            var cmd = new CreateOrganizationCommand(userId: GetCurrentUserId(), name: input.Name, description: input.Description);
            await SendCommandAsync(cmd);

            return View(input);
        }




        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            return await SendQueryAndReturnMappedDataToViewAsync<OrganizationBasicInfoDto,OrganizationInputDto>(new GetOrganizationByIdQuery(id));
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Update(OrganizationInputDto input)
        {
            if (!ModelState.IsValid)
                return View(input);

            var cmd = new UpdateOrganizationCommand(id: input.Id, name: input.Name, description: input.Description);
            await SendCommandAsync(cmd);

            return View(input);
        }



        #endregion

    }
}
