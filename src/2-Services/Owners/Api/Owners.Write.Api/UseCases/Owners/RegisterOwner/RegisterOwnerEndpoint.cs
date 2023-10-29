using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Owners.RegiserOwner;

[Authorize("user-write-access")]
[Tags("Owners")]
public class RegisterOwnerEndpoint : BaseApiController
{
    public RegisterOwnerEndpoint(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus)
        : base(authenticatedUserService, inMemoryBus) { }

    /// <summary>
    /// register new owner
    /// </summary>
    [HttpPost]
    [Route("owner")]
    [AllowAnonymous]
    public async Task<Result<CommandResult>> Post([FromBody] RegisterOwnerDto input)
    {
        return await _inMemoryBus.SendCommand<RegiserOwnerRequest>(new(displayName: input.DisplayName, email: input.Email, password: input.Password));
    }
}
