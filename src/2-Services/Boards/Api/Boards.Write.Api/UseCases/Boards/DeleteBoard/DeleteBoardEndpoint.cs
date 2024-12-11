using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Boards.Write.Api.UseCases.Boards.DeleteBoard;

[Authorize("user-write-access")]
[Tags("Boards")]
public class DeleteBoardEndpoint : BaseApiController
{
    public DeleteBoardEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// Delete a board
    /// </summary>
    [HttpDelete]
    [Route("boards/{id}")]
    public async Task<Result<CommandResult>> Delete(string id)
    {
        return await _requestDispatcher.SendCommand<DeleteBoardRequest>(new(id));
    }
}
