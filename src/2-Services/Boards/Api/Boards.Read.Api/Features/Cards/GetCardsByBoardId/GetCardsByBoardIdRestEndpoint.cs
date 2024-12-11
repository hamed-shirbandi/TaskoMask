using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Boards.Read.Api.Features.Cards.GetCardsByBoardId;

[Authorize("user-read-access")]
[Tags("Cards")]
public class GetCardsByBoardIdRestEndpoint : BaseApiController
{
    public GetCardsByBoardIdRestEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// get card info
    /// </summary>
    [HttpGet]
    [Route("boards/{boardId}/cards")]
    public async Task<Result<IEnumerable<GetCardDto>>> Get(string boardId)
    {
        return await _requestDispatcher.SendQuery(new GetCardsByBoardIdRequest(boardId));
    }
}
