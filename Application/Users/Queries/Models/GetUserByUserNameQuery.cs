using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Users.Queries.Models
{
   
    public class GetUserByUserNameQuery : BaseQuery<UserBasicInfoDto>
    {
        public GetUserByUserNameQuery(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; }
    }
}
