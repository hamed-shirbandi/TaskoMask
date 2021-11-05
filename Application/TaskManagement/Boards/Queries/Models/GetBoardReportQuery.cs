using TaskoMask.Application.Core.Dtos.TaskManagement.Boards;
using TaskoMask.Application.Core.Queries;


namespace TaskoMask.Application.TaskManagement.Boards.Queries.Models
{
   public class GetBoardReportQuery : BaseQuery<BoardReportDto>
    {
        public GetBoardReportQuery(string boardId)
        {
            BoardId = boardId;
        }

        public string BoardId { get; }
    }
}
