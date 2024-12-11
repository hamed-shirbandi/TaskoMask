using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Boards.Read.Api.Features.Cards.GetCardById;

[Authorize("user-read-access")]
[Tags("Cards")]
public class GetCardByIdRestEndpoint : BaseApiController
{
    public GetCardByIdRestEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// get card info
    /// </summary>
    [HttpGet]
    [Route("cards/{id}")]
    public async Task<Result<GetCardDto>> Get(string id)
    {
        return await _requestDispatcher.SendQuery(new GetCardByIdRequest(id));
    }
}
