using System.Collections.Generic;
using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Domain.Share.Enums;

namespace TaskoMask.Application.Workspace.Tasks.Queries.Models
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
