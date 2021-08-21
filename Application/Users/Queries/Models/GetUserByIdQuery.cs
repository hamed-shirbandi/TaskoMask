using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Domain.Entities;

namespace TaskoMask.Application.Users.Queries.Models
{
   
    public class GetUserByIdQuery<TEntity> : BaseQuery<UserBasicInfoDto> where TEntity :User
    {
        public GetUserByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
