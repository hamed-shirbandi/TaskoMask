using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Roles;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Administration.Roles.Queries.Models
{

    public class SearchRolesQuery : BaseQuery<IEnumerable<RoleBasicInfoDto>>
    {
        public SearchRolesQuery(string[] rolesId)
        {
            RolesId = rolesId;
        }

        public string[] RolesId { get; set; }
    }
}
