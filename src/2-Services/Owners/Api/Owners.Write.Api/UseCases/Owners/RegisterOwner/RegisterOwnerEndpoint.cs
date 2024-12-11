using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Owners.RegisterOwner;

[Authorize("user-write-access")]
[Tags("Owners")]
public class RegisterOwnerEndpoint : BaseApiController
{
    public RegisterOwnerEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// register new owner
    /// </summary>
    [HttpPost]
    [Route("owner")]
    [AllowAnonymous]
    public async Task<Result<CommandResult>> Post([FromBody] RegisterOwnerDto input)
    {
        return await _requestDispatcher.SendCommand<RegiserOwnerRequest>(
            new(displayName: input.DisplayName, email: input.Email, password: input.Password)
        );
    }
}
