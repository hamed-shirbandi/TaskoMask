using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Boards.Read.Api.Features.Boards.GetBoardById;

//[Authorize("user-read-access")]
[Tags("Boards")]
public class GetBoardByIdRestEndpoint : BaseApiController
{
    public GetBoardByIdRestEndpoint(IAuthenticatedUserService authenticatedUserService, IRequestDispatcher requestDispatcher)
        : base(authenticatedUserService, requestDispatcher) { }

    /// <summary>
    /// get board info
    /// </summary>
    [HttpGet]
    [Route("boards/{id}")]
    public async Task<Result<GetBoardDto>> Get(string id)
    {
        return await _requestDispatcher.SendQuery(new GetBoardByIdRequest(id));
    }
}
