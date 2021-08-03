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
        protected readonly IMapper _mapper;

        #endregion

        #region Ctor

        public OrganizationsController(IOrganizationService organizationService, IBaseApplicationService baseApplicationService, IMapper mapper) : base(baseApplicationService)
        {
            _organizationService = organizationService;
            _mapper = mapper;
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
            if (!organizationDetailQueryResult.IsSuccess)
                return RedirectToErrorPage(organizationDetailQueryResult);

            return View(organizationDetailQueryResult.Value);
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
            var organizationQueryResult = await SendQueryAsync(new GetOrganizationByIdQuery(id));
            if (!organizationQueryResult.IsSuccess)
                return RedirectToErrorPage(organizationQueryResult);

            var organization = _mapper.Map<OrganizationInputDto>(organizationQueryResult.Value);
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
            var cmd = new UpdateOrganizationCommand(id: input.Id, name: input.Name, description: input.Description);
            await SendCommandAsync(cmd);

            return View(input);
        }



        #endregion

    }
}
