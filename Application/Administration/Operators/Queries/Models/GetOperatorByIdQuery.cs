using TaskoMask.Application.Core.Dtos.Operators;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Queries;


namespace TaskoMask.Application.Administration.Operators.Queries.Models
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
