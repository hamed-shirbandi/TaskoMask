using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Api.Organizations;
using TaskoMask.Services.Owners.Write.Application.UseCases.Owners.RegiserOwner;
using TaskoMask.Services.Owners.Write.Application.UseCases.Organizations.AddOrganization;

namespace TaskoMask.Services.Owners.Write.Api.Controllers
{
    public class OrganizationsApiController : BaseApiController, IOrganizationWriteApiService
    {
        #region Fields


        #endregion

        #region Ctors

        public OrganizationsApiController(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
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
            return Result.Failure<CommandResult>();

        }



        /// <summary>
        /// Delete an organization
        /// </summary>
        [HttpDelete]
        [Route("organizations/{id}")]
        public async Task<Result<CommandResult>> Delete(string id)
        {
            return Result.Failure<CommandResult>();
        }



        #endregion

    }
}
