using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Users.Queries.Models
{
   
    public class GetUserByIdQuery : BaseQuery<UserBasicInfoDto>
    {
        public GetUserByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
