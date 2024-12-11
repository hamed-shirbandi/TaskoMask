using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Comments.GetCommentById;

[Authorize("user-read-access")]
[Tags("Comments")]
public class GetCommentByIdRestEndpoint : BaseApiController
{
    public GetCommentByIdRestEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// get comment info
    /// </summary>
    [HttpGet]
    [Route("comments/{id}")]
    public async Task<Result<GetCommentDto>> Get(string id)
    {
        return await _requestDispatcher.SendQuery(new GetCommentByIdRequest(id));
    }
}
