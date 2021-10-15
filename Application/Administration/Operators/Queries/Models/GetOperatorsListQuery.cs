using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Operators;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Administration.Operators.Queries.Models
{

    public class GetOperatorsListQuery : BaseQuery<IEnumerable<OperatorBasicInfoDto>>
    {
        public GetOperatorsListQuery()
        {
        }

    }
}
