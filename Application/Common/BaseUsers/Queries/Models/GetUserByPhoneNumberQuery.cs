using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Application.Common.BaseEntitiesUsers.Queries.Models
{
   
    public class GetUserByPhoneNumberQuery<TEntity> : BaseQuery<UserBasicInfoDto> where TEntity : BaseUser
    {
        public GetUserByPhoneNumberQuery(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public string PhoneNumber { get; }
    }
}
