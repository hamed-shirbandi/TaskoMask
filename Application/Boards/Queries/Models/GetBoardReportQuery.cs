using MediatR;
using TaskoMask.Application.Core.Dtos.Boards;

namespace TaskoMask.Application.Boards.Queries.Models
{
   public class GetBoardReportQuery : IRequest<BoardReportDto>
    {
        public GetBoardReportQuery(string boardId)
        {
            BoardId = boardId;
        }

        public string BoardId { get; }
    }
}
