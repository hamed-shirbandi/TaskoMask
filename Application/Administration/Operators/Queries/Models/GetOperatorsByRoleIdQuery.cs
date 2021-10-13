using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Operators;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Administration.Operators.Queries.Models
{

    public class GetOperatorsByRoleIdQuery : BaseQuery<IEnumerable<OperatorBasicInfoDto>>
    {
        public GetOperatorsByRoleIdQuery(string roleId)
        {
            RoleId = roleId;
        }

        public string RoleId { get; }
    }
}
