using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Organizations.AddOrganization
{
    [Authorize("user-write-access")]
    [Tags("Organizations")]
    public class AddOrganizationEndpoint : BaseApiController
    {
        public AddOrganizationEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus)
            : base(authenticatedUserService, inMemoryBus) { }

        /// <summary>
        /// Add new organization for current owner
        /// </summary>
        [HttpPost]
        [Route("organizations")]
        public async Task<Result<CommandResult>> Post([FromBody] AddOrganizationDto input)
        {
            input.OwnerId = GetCurrentUserId();
            return await _inMemoryBus.SendCommand<AddOrganizationRequest>(
                new(ownerId: input.OwnerId, name: input.Name, description: input.Description)
            );
        }
    }
}
