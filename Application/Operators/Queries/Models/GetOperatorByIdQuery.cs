using TaskoMask.Application.Core.Dtos.Operators;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Domain.Entities;

namespace TaskoMask.Application.Operators.Queries.Models
{
   
    public class GetOperatorByIdQuery : BaseQuery<OperatorBasicInfoDto>
    {
        public GetOperatorByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
