using TaskoMask.Application.Core.Dtos.Team.Organizations;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Team.Organizations.Queries.Models
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
