using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;

namespace TaskoMask.Services.Boards.Read.Api.Features.Boards.GetBoardById
{
    public class GetBoardByIdRequest : BaseQuery<GetBoardDto>
    {
        public GetBoardByIdRequest(string id)
        {
            Id = id;
        }


        public string Id { get; }


    }
}
