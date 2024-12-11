using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;

namespace TaskoMask.Services.Boards.Write.Api.UseCases.Boards.AddBoard;

[Authorize("user-write-access")]
[Tags("Boards")]
public class AddBoardEndpoint : BaseApiController
{
    public AddBoardEndpoint(ICurrentUser currentUser, IRequestDispatcher requestDispatcher)
        : base(currentUser, requestDispatcher) { }

    /// <summary>
    /// Add new board
    /// </summary>
    [HttpPost]
    [Route("boards")]
    public async Task<Result<CommandResult>> Post([FromBody] AddBoardDto input)
    {
        return await _requestDispatcher.SendCommand<AddBoardRequest>(
            new(projectId: input.ProjectId, name: input.Name, description: input.Description)
        );
    }
}
