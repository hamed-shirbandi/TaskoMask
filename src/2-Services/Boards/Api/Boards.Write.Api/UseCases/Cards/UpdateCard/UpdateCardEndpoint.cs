using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Boards.Write.Api.UseCases.Cards.UpdateCard;

[Authorize("user-write-access")]
[Tags("Cards")]
public class UpdateCardEndpoint : BaseApiController
{
    public UpdateCardEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// Update an existing card
    /// </summary>
    [HttpPut]
    [Route("cards/{id}")]
    public async Task<Result<CommandResult>> Put(string id, [FromBody] UpdateCardDto input)
    {
        return await _requestDispatcher.SendCommand<UpdateCardRequest>(new(id: id, name: input.Name, type: input.Type));
    }
}
