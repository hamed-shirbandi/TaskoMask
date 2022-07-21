using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Workspace.Organizations.Services;
using TaskoMask.Application.Share.Dtos.Workspace.Organizations;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.Presentation.Framework.Web.Controllers;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Domain.Core.Services;

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
        public async Task<Result<CommandResult>> Create([FromBody] OrganizationUpsertDto input)
        {
            input.OwnerId = GetCurrentUserId();
            return await _organizationService.CreateAsync(input);
        }



        /// <summary>
        /// update existing organization
        /// </summary>
        [HttpPut]
        [Route("organizations/{id}")]
        public async Task<Result<CommandResult>> Update(string id,[FromBody] OrganizationUpsertDto input)
        {
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
            return await _organizationService.DeleteAsync(id);
        }



        #endregion

    }
}
