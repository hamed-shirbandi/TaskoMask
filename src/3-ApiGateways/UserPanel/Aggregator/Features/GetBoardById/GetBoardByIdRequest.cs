using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Features.GetBoardById
{
    public class GetBoardByIdRequest : BaseQuery<BoardDetailsViewModel>
    {
        public GetBoardByIdRequest(string id)
        {
            Id = id;
        }

        public string Id { get; }

    }
}
