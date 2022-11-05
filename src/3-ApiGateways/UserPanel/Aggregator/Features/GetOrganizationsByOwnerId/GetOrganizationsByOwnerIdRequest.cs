using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Features.GetOrganizationsByOwnerId
{
    public class GetOrganizationsByOwnerIdRequest : BaseQuery<IEnumerable<OrganizationDetailsViewModel>>
    {
        public GetOrganizationsByOwnerIdRequest(string ownerId)
        {
            OwnerId = ownerId;
        }

        public string OwnerId { get; }

    }
}
