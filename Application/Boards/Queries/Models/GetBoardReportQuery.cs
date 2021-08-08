using MediatR;
using TaskoMask.Application.Core.Dtos.Boards;
using TaskoMask.Domain.Core.Queries;


namespace TaskoMask.Application.Boards.Queries.Models
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
