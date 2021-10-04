using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Application.Common.BaseEntitiesUsers.Queries.Models
{
   
    public class GetUserByIdQuery<TEntity> : BaseQuery<UserBasicInfoDto> where TEntity :BaseUser
    {
        public GetUserByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
