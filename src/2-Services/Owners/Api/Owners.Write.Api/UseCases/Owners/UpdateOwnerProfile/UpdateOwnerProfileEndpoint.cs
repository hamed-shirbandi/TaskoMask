using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Owners.UpdateOwnerProfile
{

    [Authorize("user-write-access")]
    [Tags("Owners")]
    public class UpdateOwnerProfileEndpoint : BaseApiController
    {
        public UpdateOwnerProfileEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus) : base(authenticatedUserService, inMemoryBus)
        {
        }



        /// <summary>
        /// Update current owner
        /// </summary>
        [HttpPut]
        [Route("owner")]
        public async Task<Result<CommandResult>> Put([FromBody] UpdateOwnerProfileDto input)
        {
            return await _inMemoryBus.SendCommand<UpdateOwnerProfileRequest>(new(id: input.Id, displayName: input.DisplayName, email: input.Email));
        }

    }

}