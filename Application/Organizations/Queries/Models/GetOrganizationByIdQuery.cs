using TaskoMask.Application.Core.Dtos.Organizations;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Organizations.Queries.Models
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
