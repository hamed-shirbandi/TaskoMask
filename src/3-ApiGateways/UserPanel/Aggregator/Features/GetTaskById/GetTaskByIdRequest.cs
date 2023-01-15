using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Features.GetTaskById
{
    public class GetTaskByIdRequest : BaseQuery<TaskDetailsViewModel>
    {
        public GetTaskByIdRequest(string id)
        {
            Id = id;
        }

        public string Id { get; }

    }
}
