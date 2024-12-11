using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Boards.Write.Api.UseCases.Cards.AddCard;

[Authorize("user-write-access")]
[Tags("Cards")]
public class AddCardEndpoint : BaseApiController
{
    public AddCardEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// Add new card
    /// </summary>
    [HttpPost]
    [Route("cards")]
    public async Task<Result<CommandResult>> Add([FromBody] AddCardDto input)
    {
        return await _requestDispatcher.SendCommand<AddCardRequest>(new(boardId: input.BoardId, name: input.Name, type: input.Type));
    }
}
