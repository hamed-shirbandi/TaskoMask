using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Domain.Entities;

namespace TaskoMask.Application.Users.Queries.Models
{
   
    public class GetUserByUserNameQuery<TEntity> : BaseQuery<UserBasicInfoDto> where TEntity : BaseUser
    {
        public GetUserByUserNameQuery(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; }
    }
}
