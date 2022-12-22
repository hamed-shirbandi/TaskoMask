using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Application.Queries;

namespace TaskoMask.Services.Monolith.Application.Queries.Models.Boards
{
   
    public class GetBoardByIdQuery : BaseQuery<GetBoardDto>
    {
        public GetBoardByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
