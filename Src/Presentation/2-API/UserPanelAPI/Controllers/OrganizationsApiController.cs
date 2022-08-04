using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Workspace.Organizations.Services;
using TaskoMask.Application.Share.Dtos.Workspace.Organizations;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.Presentation.Framework.Web.Controllers;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TaskoMask.Presentation.Framework.Share.ApiContracts;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Application.Core.Services;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Presentation.API.UserPanelAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrganizationsApiController : BaseApiController, IOrganizationApiService
    {
        #region Fields

        private readonly IOrganizationService _organizationService;
        private readonly IUserAccessManagementService _userAccessManagementService;

        #endregion

        #region Ctors

        public OrganizationsApiController(IOrganizationService organizationService, IAuthenticatedUserService authenticatedUserService, IUserAccessManagementService userAccessManagementService) : base(authenticatedUserService)
        {
            _organizationService = organizationService;
            _userAccessManagementService = userAccessManagementService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// get organization basic info
        /// </summary>
        [HttpGet]
        [Route("organizations/{id}")]
        public async Task<Result<OrganizationBasicInfoDto>> Get(string id)
        {
            if (!await _userAccessManagementService.CanAccessToOrganizationAsync(id))
                return Result.Failure<OrganizationBasicInfoDto>(message: DomainMessages.Access_Denied);

            return await _organizationService.GetByIdAsync(id);
        }



        /// <summary>
        /// get organizations list with all relational data for current user
        /// </summary>
        [HttpGet]
        [Route("organizations")]
        public async Task<Result<IEnumerable<OrganizationDetailsViewModel>>> Get()
        {
            return await _organizationService.GetListWithDetailsByOwnerIdAsync(GetCurrentUserId());
        }



        /// <summary>
        /// get organizations select list for current user
        /// </summary>
        [HttpGet]
        [Route("owner/organizations")]
        public async Task<Result<IEnumerable<SelectListItem>>> GetSelectListItems()
        {
            return await _organizationService.GetSelectListAsync(GetCurrentUserId());
        }


        

        /// <summary>
        /// create new organization
        /// </summary>
        [HttpPost]
        [Route("organizations")]
        public async Task<Result<CommandResult>> Add([FromBody] AddOrganizationDto input)
        {
            input.OwnerId = GetCurrentUserId();
            return await _organizationService.AddAsync(input);
        }



        /// <summary>
        /// update existing organization
        /// </summary>
        [HttpPut]
        [Route("organizations/{id}")]
        public async Task<Result<CommandResult>> Update(string id,[FromBody] UpdateOrganizationDto input)
        {
            if (!await _userAccessManagementService.CanAccessToOrganizationAsync(id))
                return Result.Failure<CommandResult>(message: DomainMessages.Access_Denied);

            input.Id = id;
            return await _organizationService.UpdateAsync(input);
        }



        /// <summary>
        /// soft delete organization
        /// </summary>
        [HttpDelete]
        [Route("organizations/{id}")]
        public async Task<Result<CommandResult>> Delete(string id)
        {
            if (!await _userAccessManagementService.CanAccessToOrganizationAsync(id))
                return Result.Failure<CommandResult>(message: DomainMessages.Access_Denied);

            return await _organizationService.DeleteAsync(id);
        }



        #endregion

    }
}
