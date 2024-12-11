using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Boards.Write.Api.UseCases.Cards.DeleteCard;

[Authorize("user-write-access")]
[Tags("Cards")]
public class DeleteCardEndpoint : BaseApiController
{
    public DeleteCardEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// Delete a card
    /// </summary>
    [HttpDelete]
    [Route("cards/{id}")]
    public async Task<Result<CommandResult>> Delete(string id)
    {
        return await _requestDispatcher.SendCommand<DeleteCardRequest>(new(id));
    }
}
