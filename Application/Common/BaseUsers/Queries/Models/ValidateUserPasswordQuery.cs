using TaskoMask.Application.Core.Queries;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Application.Common.BaseEntitiesUsers.Queries.Models
{
    public class ValidateUserPasswordQuery<TEntity> : BaseQuery<bool> where TEntity : BaseUser
    {
        public ValidateUserPasswordQuery(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; }
        public string Password { get; }
    }
}
