using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Team.Organizations.Services;
using TaskoMask.Application.Share.Dtos.Team.Organizations;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.Presentation.Framework.Web.Controllers;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Domain.Share.Services;

namespace TaskoMask.Presentation.API.UserPanelAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrganizationsController : BaseApiController, IOrganizationClientService
    {
        #region Fields

        private readonly IOrganizationService _organizationService;

        #endregion

        #region Ctors

        public OrganizationsController(IOrganizationService organizationService, IAuthenticatedUserService authenticatedUserService):base(authenticatedUserService)
        {
            _organizationService = organizationService;
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
            return await _organizationService.GetByIdAsync(id);
        }



        /// <summary>
        /// get organizations list for current user
        /// </summary>
        [HttpGet]
        [Route("organizations")]
        public async Task<Result<IEnumerable<OrganizationDetailsViewModel>>> Get()
        {
            return await _organizationService.GetListWithDetailsByOwnerMemberIdAsync(GetCurrentUserId());
        }




        /// <summary>
        /// create new organization
        /// </summary>
        [HttpPost]
        [Route("organizations")]
        public async Task<Result<CommandResult>> Create([FromBody] OrganizationUpsertDto input)
        {
            input.OwnerMemberId = GetCurrentUserId();
            return await _organizationService.CreateAsync(input);
        }



        /// <summary>
        /// update existing organization
        /// </summary>
        [HttpPut]
        [Route("organizations")]
        public async Task<Result<CommandResult>> Update([FromBody] OrganizationUpsertDto input)
        {
            return await _organizationService.UpdateAsync(input);
        }



        /// <summary>
        /// soft delete organization
        /// </summary>
        [HttpDelete]
        [Route("organizations")]
        public async Task<Result<CommandResult>> Delete(string id)
        {
            return await _organizationService.DeleteAsync(id);
        }



        #endregion

    }
}
