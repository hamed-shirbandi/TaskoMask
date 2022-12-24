using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Application.Queries;

namespace TaskoMask.Services.Monolith.Application.Workspace.Tasks.Queries.Models
{
    public class GetPendingTasksByBoardsIdQuery : BaseQuery<IEnumerable<GetTaskDto>>
    {
        public GetPendingTasksByBoardsIdQuery(string[] boardsId, int takeCount)
        {
            BoardsId = boardsId;
            TakeCount = takeCount;
        }

        public int TakeCount { get; }
        public string[] BoardsId { get; }
    }
}
