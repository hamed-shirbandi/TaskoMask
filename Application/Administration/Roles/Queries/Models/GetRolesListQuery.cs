using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Roles;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Administration.Roles.Queries.Models
{

    public class GetRolesListQuery : BaseQuery<IEnumerable<RoleBasicInfoDto>>
    {
        public GetRolesListQuery()
        {

        }


    }
}
