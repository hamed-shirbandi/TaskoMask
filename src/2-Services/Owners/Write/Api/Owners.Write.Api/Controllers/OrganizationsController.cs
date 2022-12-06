using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.Services.Owners.Write.Application.UseCases.Organizations.AddOrganization;
using TaskoMask.Services.Owners.Write.Application.UseCases.Organizations.UpdateOrganization;
using TaskoMask.Services.Owners.Write.Application.UseCases.Organizations.DeleteOrganization;
using Microsoft.AspNetCore.Authorization;

namespace TaskoMask.Services.Owners.Write.Api.Controllers
{
    [Authorize("user-write-access")]
    public class OrganizationsController : BaseApiController
    {
        #region Fields


        #endregion

        #region Ctors

        public OrganizationsController(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
        {
        }


        #endregion

        #region Public Methods



        /// <summary>
        /// Add new organization for current owner
        /// </summary>
        [HttpPost]
        [Route("organizations")]
        public async Task<Result<CommandResult>> Add([FromBody] AddOrganizationDto input)
        {
            input.OwnerId = GetCurrentUserId();
            return await _inMemoryBus.SendCommand<AddOrganizationRequest>(new(ownerId: input.OwnerId, name: input.Name, description: input.Description));
        }



        /// <summary>
        /// Update an existing organization
        /// </summary>
        [HttpPut]
        [Route("organizations/{id}")]
        public async Task<Result<CommandResult>> Update(string id,[FromBody] UpdateOrganizationDto input)
        {
            return await _inMemoryBus.SendCommand<UpdateOrganizationRequest>(new(id: input.Id, name: input.Name, description: input.Description));
        }



        /// <summary>
        /// Delete an organization
        /// </summary>
        [HttpDelete]
        [Route("organizations/{id}")]
        public async Task<Result<CommandResult>> Delete(string id)
        {
            return await _inMemoryBus.SendCommand<DeleteOrganizationRequest>(new(id));
        }



        #endregion

    }
}
