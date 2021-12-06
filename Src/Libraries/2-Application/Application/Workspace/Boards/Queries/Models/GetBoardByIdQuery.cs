using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Queries.Models.Boards
{
   
    public class GetBoardByIdQuery : BaseQuery<BoardBasicInfoDto>
    {
        public GetBoardByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
