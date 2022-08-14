using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Tasks;
using TaskoMask.Services.Monolith.Application.Core.Queries;

namespace TaskoMask.Services.Monolith.Application.Workspace.Tasks.Queries.Models
{
    public class GetPendingTasksByBoardsIdQuery : BaseQuery<IEnumerable<TaskBasicInfoDto>>
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
