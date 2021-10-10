using TaskoMask.Application.Core.Dtos.Roles;
using TaskoMask.Application.Core.Queries;


namespace TaskoMask.Application.Administration.Roles.Queries.Models
{
   
    public class GetRoleByIdQuery : BaseQuery<RoleBasicInfoDto>
    {
        public GetRoleByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
