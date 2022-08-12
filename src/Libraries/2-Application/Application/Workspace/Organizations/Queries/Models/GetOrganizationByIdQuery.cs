using TaskoMask.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Workspace.Organizations.Queries.Models
{
   
    public class GetOrganizationByIdQuery : BaseQuery<OrganizationBasicInfoDto>
    {
        public GetOrganizationByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
