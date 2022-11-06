using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Features.GetProjectById
{
    public class GetProjectByIdRequest : BaseQuery<ProjectDetailsViewModel>
    {
        public GetProjectByIdRequest(string id)
        {
            Id = id;
        }

        public string Id { get; }

    }
}
