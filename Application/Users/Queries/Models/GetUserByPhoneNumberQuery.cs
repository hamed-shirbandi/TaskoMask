using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Domain.Entities;

namespace TaskoMask.Application.Users.Queries.Models
{
   
    public class GetUserByPhoneNumberQuery<TEntity> : BaseQuery<UserBasicInfoDto> where TEntity : User
    {
        public GetUserByPhoneNumberQuery(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public string PhoneNumber { get; }
    }
}
