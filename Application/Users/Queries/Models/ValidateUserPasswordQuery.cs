using TaskoMask.Application.Core.Queries;
using TaskoMask.Domain.Entities;

namespace TaskoMask.Application.Users.Queries.Models
{
    public class ValidateUserPasswordQuery<TEntity> : BaseQuery<bool> where TEntity : User
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
