using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Boards.Write.Api.UseCases.Boards.UpdateBoard;

[Authorize("user-write-access")]
[Tags("Boards")]
public class UpdateBoardEndpoint : BaseApiController
{
    public UpdateBoardEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// Update an existing board
    /// </summary>
    [HttpPut]
    [Route("boards/{id}")]
    public async Task<Result<CommandResult>> Put(string id, [FromBody] UpdateBoardDto input)
    {
        return await _requestDispatcher.SendCommand<UpdateBoardRequest>(new(id: id, name: input.Name, description: input.Description));
    }
}
